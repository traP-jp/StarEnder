using System;
using System.Collections.Generic;
using h24s_15.Battle.Enemy;
using h24s_15.Battle.PlayerCharacter;
using R3;
using UnityEngine;

namespace h24s_15.Battle.TurnBattleSystem {
    [Serializable]
    public class TurnBattleData {
        public IPlayerCharacter CurrentPlayerCharacter;
        public List<IEnemy> CurrentEnemies;
        public ReactiveProperty<int> ElapsedTurnCount;
    }
}
