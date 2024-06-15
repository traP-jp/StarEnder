using System.Threading;
using Cysharp.Threading.Tasks;
using h24s_15.Battle.Actions;
using h24s_15.Battle.PlayerCharacter;
using R3;
using UnityEngine;

namespace h24s_15.Battle.Enemy {
    public class NormalEnemy : MonoBehaviour, IEnemy {
        private ReactiveProperty<int> _currentMaxHp = new();
        private ReactiveProperty<int> _currentHp = new();
        private ReactiveProperty<int> _currentShield = new();
        private ReactiveProperty<IActionData> _nextAction = new();
        private ReactiveProperty<IPlayerCharacter> _nextActionTargetPlayerCharacter = new();

        public ReadOnlyReactiveProperty<int> CurrentMaxHp => _currentMaxHp.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<int> CurrentHp => _currentHp.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<int> CurrentShield => _currentShield.ToReadOnlyReactiveProperty();
        public ReadOnlyReactiveProperty<IActionData> NextAction => _nextAction.ToReadOnlyReactiveProperty();
        public ReactiveProperty<IPlayerCharacter> NextActionTargetPlayerCharacter => _nextActionTargetPlayerCharacter;

        public async UniTask Act(CancellationToken token) {
            await _nextActionTargetPlayerCharacter.Value.ReceiveAttack(_nextAction.Value, token);
        }

        public async UniTask ReceiveAttack(IActionData actionData, CancellationToken token) {
            var damage = actionData.SingleAttackValue;
            _currentHp.Value -= damage;
        }
    }
}
