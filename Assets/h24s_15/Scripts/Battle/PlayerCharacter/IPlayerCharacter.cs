using h24s_15.Battle.Character;
using h24s_15.Battle.Enemy;
using R3;

namespace h24s_15.Battle.PlayerCharacter {
    public interface IPlayerCharacter : IBattleCharacter {
        public ReactiveProperty<IEnemy> NextActionTargetEnemy { get; }
    }
}
