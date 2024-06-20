using System.Threading;
using Cysharp.Threading.Tasks;
using h24s_15.Battle.Rolling.Actions;
using R3;

namespace h24s_15.Battle.Character {
    public interface IBattleCharacter {
        public ReadOnlyReactiveProperty<int> CurrentMaxHp { get; }
        public ReadOnlyReactiveProperty<int> CurrentHp { get; }
        public ReadOnlyReactiveProperty<int> CurrentShield { get; }
        public Observable<Unit> OnDefeated { get; }
        public UniTask<bool> Act(CancellationToken token);
        public UniTask<bool> ReceiveAttack(IActionData actionData, CancellationToken token);
    }
}
