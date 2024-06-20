using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using h24s_15.Battle.PlayerCharacter;
using h24s_15.Battle.Rolling;
using h24s_15.Battle.Rolling.Actions;
using h24s_15.Battle.TurnBattleSystem;
using h24s_15.Utils;
using R3;
using UnityEngine;

namespace h24s_15.Battle.Enemy {
    public class NormalEnemy : MonoBehaviour, IEnemy {
        [SerializeField] private List<ActionWithWeight> _actionWithWeights;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [Header("パラメーター")]
        [Tooltip("最初のHP")] [SerializeField] private int _initialHp = 40;

        private readonly AliasMethod _actionGacha = new();
        private ReactiveProperty<int> _currentMaxHp;
        private ReactiveProperty<int> _currentHp;
        private ReactiveProperty<int> _currentShield = new();
        private ReactiveProperty<IActionData> _nextAction = new();
        private ReactiveProperty<IPlayerCharacter> _nextActionTargetPlayerCharacter = new();
        private readonly ReactiveProperty<bool> _isDefeated = new(false);

        public ReadOnlyReactiveProperty<int> CurrentMaxHp => _currentMaxHp.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<int> CurrentHp => _currentHp.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<int> CurrentShield => _currentShield.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<IActionData> NextAction => _nextAction.ToReadOnlyReactiveProperty();
        public Observable<Unit> OnDefeated => _isDefeated.Where(x => x).AsUnitObservable();
        public ReactiveProperty<IPlayerCharacter> NextActionTargetPlayerCharacter => _nextActionTargetPlayerCharacter;
        public ReadOnlyReactiveProperty<bool> IsDefeated => _isDefeated.ToReadOnlyReactiveProperty();

        private void Awake() {
            _actionGacha.Constructor(_actionWithWeights.Select(x => x.Weight).ToArray());

            _currentMaxHp = new ReactiveProperty<int>(_initialHp);
            _currentHp = new ReactiveProperty<int>(_initialHp);
        }

        private void Start() {
            _nextActionTargetPlayerCharacter.Value = FindObjectsByType<GameObject>(FindObjectsSortMode.None)
                .First(obj => obj.GetComponent<IPlayerCharacter>() != null).GetComponent<IPlayerCharacter>();
        }

        public async UniTask<bool> Act(CancellationToken token) {
            _nextAction.Value = _actionWithWeights[_actionGacha.Roll()].ActionData;
            return await _nextActionTargetPlayerCharacter.Value.ReceiveAttack(
                _nextAction.Value, token);
        }

        public async UniTask<bool> ReceiveAttack(IActionData actionData, CancellationToken token) {
            var damage = actionData.SingleAttackValue;
            var computedHp = _currentHp.Value - damage;

            Debug.Log($"敵に{damage}のダメージを与え、残りHPは{computedHp}です");

            if (computedHp <= 0) {
                _currentHp.Value = 0;
                transform.DOShakePosition(0.5f, 0.5f, 10, 90, false, true);
                _spriteRenderer.DOFade(0.0f, 0.5f);

                await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);

                _isDefeated.Value = true;
                return true;
            }
            else {
                _currentHp.Value = computedHp;
                return false;
            }
        }
    }
}
