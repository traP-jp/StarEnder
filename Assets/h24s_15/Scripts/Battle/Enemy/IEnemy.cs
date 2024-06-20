using h24s_15.Battle.Character;
using h24s_15.Battle.PlayerCharacter;
using h24s_15.Battle.Rolling.Actions;
using R3;

namespace h24s_15.Battle.Enemy {
    public interface IEnemy : IBattleCharacter {
        public ReadOnlyReactiveProperty<IActionData> NextAction { get; }
        public ReactiveProperty<IPlayerCharacter> NextActionTargetPlayerCharacter { get; }
        public ReadOnlyReactiveProperty<bool> IsDefeated { get; }
    }
}
