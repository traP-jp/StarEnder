using System.Threading;
using Cysharp.Threading.Tasks;
using h24s_15.Battle.Actions;
using R3;

namespace h24s_15.Battle.Character {
    public interface IBattleCharacter {
        public ReadOnlyReactiveProperty<int> CurrentMaxHp { get; }
        public ReadOnlyReactiveProperty<int> CurrentHp { get; }
        public ReadOnlyReactiveProperty<int> CurrentShield { get; }
        public ReadOnlyReactiveProperty<IActionData> NextAction { get; }
        public UniTask Act(CancellationToken token);
        public UniTask ReceiveAttack(IActionData actionData, CancellationToken token);
    }
}
