using R3;

namespace h24s_15.Battle.Character {
    public interface IBattleCharacter {
        public ReadOnlyReactiveProperty<int> CurrentHp { get; }
        public ReadOnlyReactiveProperty<int> CurrentShield { get; }
    }
}
