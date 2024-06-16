using System;
using System.Collections.Generic;
using h24s_15.Battle.Enemy;
using h24s_15.Battle.PlayerCharacter;
using h24s_15.Battle.Rolling;
using R3;

namespace h24s_15.Battle.TurnBattleSystem {
    [Serializable]
    public class TurnBattleData {
        public IPlayerCharacter CurrentPlayerCharacter;
        public List<IEnemy> CurrentEnemies = new();
        public ReactiveProperty<int> ElapsedTurnCount = new(0);
        public DiceHistory DiceHistory;
        public ReactiveProperty<int> RemainingOperateCount;
    }
}
