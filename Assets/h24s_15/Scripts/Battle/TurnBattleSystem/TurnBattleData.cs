using System;
using System.Collections.Generic;
using h24s_15.Battle.Enemy;
using h24s_15.Battle.PlayerCharacter;
using h24s_15.Battle.Rolling;
using R3;
using UnityEngine;

namespace h24s_15.Battle.TurnBattleSystem {
    [Serializable]
    public class TurnBattleData {
        [SerializeField] private int _reRollOrSubmitTicketMaxCount = 4;
        private ReactiveProperty<int> _remainingOperateCount;

        public IPlayerCharacter CurrentPlayerCharacter;
        public List<IEnemy> CurrentEnemies = new();
        public ReactiveProperty<int> ElapsedTurnCount = new(0);
        public DiceHistory DiceHistory;

        public int ReRollOrSubmitTicketMaxCount => _reRollOrSubmitTicketMaxCount;

        public ReactiveProperty<int> RemainingOperateCount {
            get {
                if (_remainingOperateCount == null) {
                    _remainingOperateCount = new ReactiveProperty<int>(_reRollOrSubmitTicketMaxCount);
                }

                return _remainingOperateCount;
            }
        }
    }
}
