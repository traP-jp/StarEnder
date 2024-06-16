using System;
using Cysharp.Threading.Tasks;
using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.TurnBattleSystem {
    public class TurnBattleManager : SingletonMonoBehaviour<TurnBattleManager> {
        [SerializeField] private TurnBattleData _data;

        public TurnBattleData Data => _data;

        public async void OnTurnEnd() {
            // プレイヤーが攻撃.
            await _data.CurrentPlayerCharacter.Act(this.GetCancellationTokenOnDestroy());

            // エネミーたちが攻撃.
            foreach (var enemy in _data.CurrentEnemies) {
                await enemy.Act(this.GetCancellationTokenOnDestroy());
            }

            // ターンを増加.
            _data.ElapsedTurnCount.Value++;
        }
    }
}
