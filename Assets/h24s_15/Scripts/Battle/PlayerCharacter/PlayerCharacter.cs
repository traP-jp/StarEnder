using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using h24s_15.Battle.Actions;
using h24s_15.Battle.Enemy;
using h24s_15.Battle.Rolling;
using h24s_15.Battle.TurnBattleSystem;
using R3;
using UnityEngine;

namespace h24s_15.Battle.PlayerCharacter {
    public class PlayerCharacter : MonoBehaviour, IPlayerCharacter {
        [SerializeField] private int _initialHp;

        private ReactiveProperty<int> _currentMaxHp;
        private ReactiveProperty<int> _currentHp;
        private ReactiveProperty<int> _currentShield = new();
        private ReactiveProperty<IActionData> _nextAction = new();
        private ReactiveProperty<IEnemy> _nextActionTargetEnemy = new();

        public ReadOnlyReactiveProperty<int> CurrentMaxHp => _currentMaxHp.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<int> CurrentHp => _currentHp.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<int> CurrentShield => _currentShield.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<IActionData> NextAction => _nextAction.ToReadOnlyReactiveProperty();
        public ReactiveProperty<IEnemy> NextActionTargetEnemy => _nextActionTargetEnemy;

        private void Awake() {
            _currentMaxHp = new ReactiveProperty<int>(_initialHp);
            _currentHp = new ReactiveProperty<int>(_initialHp);
        }

        private void Start() {
            TurnBattleManager.Instance.Data.CurrentPlayerCharacter = this;

            _nextActionTargetEnemy.Value = FindObjectsByType<GameObject>(FindObjectsSortMode.None)
                .First(obj => obj.GetComponent<IEnemy>() != null).GetComponent<IEnemy>();
        }

        public async UniTask<bool> Act(CancellationToken token) {
            _nextAction.Value = RollResultToActionConverter.CompositeActionData(
                DiceHistory.Instance.History.Select(x => x.ActionData).ToList());
            DiceHistory.Instance.ClearHistory();
            return await _nextActionTargetEnemy.Value.ReceiveAttack(_nextAction.Value, token);
        }

        public async UniTask<bool> ReceiveAttack(IActionData actionData, CancellationToken token) {
            var damage = actionData.SingleAttackValue;
            var computedHp = _currentHp.Value - damage;

            Debug.Log($"プレイヤーは{damage}のダメージを受け、残りHPは{computedHp}です");

            if (computedHp <= 0) {
                _currentHp.Value = 0;
                TurnBattleManager.Instance.OnDefeated();
                return true;
            }
            else {
                _currentHp.Value = computedHp;
                return false;
            }
        }
    }
}
