using h24s_15.Battle.Character;
using h24s_15.Battle.PlayerCharacter;
using R3;

namespace h24s_15.Battle.Enemy {
    public interface IEnemy : IBattleCharacter {
        public ReactiveProperty<IPlayerCharacter> NextActionTargetPlayerCharacter { get; }
    }
}
