using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using h24s_15.Battle.Rolling;
using h24s_15.Buff;
using h24s_15.Utils;
using h24s_15.Utils.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;

namespace h24s_15.Battle.TurnBattleSystem {
    public class TurnBattleManager : SingletonMonoBehaviour<TurnBattleManager> {
        [SerializeField] private TurnBattleData _data;
        [SerializeField] private Image _overlayImage;
        [SerializeField] private TMP_Text _remainingTicketText;

        public TurnBattleData Data => _data;

        private bool _isTurnEnding = false;

        protected override void Awake() {
            base.Awake();

            _overlayImage.enabled = false;
        }

        private void Start() {
            _data.RemainingOperateCount.Subscribe(ticketCount => {
                // 全角の数字にする.
                _remainingTicketText.text = ticketCount.ToString().ToFullNumber();
            }).AddTo(this);

            _data.RemainingOperateCount.Value = _data.ReRollOrSubmitTicketMaxCount;
        }

        public async void OnTurnEnd() {
            if (_isTurnEnding) {
                return;
            }

            _isTurnEnding = true;

            Debug.Log($"ターンエンド");

            // プレイヤーが攻撃.
            var isGameEnd = await _data.CurrentPlayerCharacter.Act(this.GetCancellationTokenOnDestroy());

            if (isGameEnd) {
                return;
            }

            // エネミーたちが攻撃.
            foreach (var enemy in _data.CurrentEnemies) {
                isGameEnd = false;
                isGameEnd = await enemy.Act(this.GetCancellationTokenOnDestroy());

                if (isGameEnd) {
                    return;
                }
            }

            // ターンを増加.
            _data.ElapsedTurnCount.Value++;

            Debug.Log($"次のターンが始まりました");
            _isTurnEnding = false;
            _data.RemainingOperateCount.Value = _data.ReRollOrSubmitTicketMaxCount;
            DiceSetManager.Instance.RollAll();
        }

        public async void OnDefeatEnemy() {
            Debug.Log($"敵を倒した！");
            BuffSelectManager.Instance.DisplayBuffSelect();
        }

        public async void OnDefeated() {
            _overlayImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            _overlayImage.enabled = true;
            Debug.Log("やられた！");
            _overlayImage.DOFade(1.0f, 1.0f);
            ProgressManager.resetProgress();
            ProgressManager.toStageSelect();
        }
    }
}
