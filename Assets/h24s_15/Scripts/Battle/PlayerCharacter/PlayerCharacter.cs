using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using h24s_15.Battle.Enemy;
using h24s_15.Battle.Rolling;
using h24s_15.Battle.Rolling.Actions;
using h24s_15.Utils.Extensions;
using R3;
using UnityEngine;
using Unit = R3.Unit;

namespace h24s_15.Battle.PlayerCharacter {
    public class PlayerCharacter : MonoBehaviour, IPlayerCharacter {
        [SerializeField] private int _initialHp;

        private ReactiveProperty<int> _currentMaxHp;
        private ReactiveProperty<int> _currentHp;
        private ReactiveProperty<int> _currentShield = new();
        private ReactiveProperty<IEnemy> _nextActionTargetEnemy = new();
        private readonly Subject<Unit> _onDefeated = new();

        public ReadOnlyReactiveProperty<int> CurrentMaxHp => _currentMaxHp.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<int> CurrentHp => _currentHp.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<int> CurrentShield => _currentShield.ToReadOnlyReactiveProperty();
        public Observable<Unit> OnDefeated => _onDefeated;
        public ReactiveProperty<IEnemy> NextActionTargetEnemy => _nextActionTargetEnemy;

        private void Awake() {
            _currentMaxHp = new ReactiveProperty<int>(_initialHp);
            _currentHp = new ReactiveProperty<int>(_initialHp);
        }

        private void Start() {
            _nextActionTargetEnemy.Value = UnityObjectUtils.FindObjectByInterface<IEnemy>();
        }

        public async UniTask<bool> Act(CancellationToken token) {
            var nextAction = RollResultToActionConverter.CompositeActionData(
                DiceHistory.Instance.HistoryUnits.Select(x => x.ActionData).ToList());
            DiceHistory.Instance.ClearHistory();
            return await _nextActionTargetEnemy.Value.ReceiveAttack(nextAction, token);
        }

        public async UniTask<bool> ReceiveAttack(IActionData actionData, CancellationToken token) {
            var damage = actionData.SingleAttackValue;
            var computedHp = _currentHp.Value - damage;

            Debug.Log($"プレイヤーは{damage}のダメージを受け、残りHPは{computedHp}です");

            if (computedHp <= 0) {
                _currentHp.Value = 0;
                _onDefeated.OnNext(Unit.Default);
                return true;
            }
            else {
                _currentHp.Value = computedHp;
                return false;
            }
        }
    }
}
