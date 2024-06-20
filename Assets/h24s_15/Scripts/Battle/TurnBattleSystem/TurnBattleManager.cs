using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using h24s_15.Battle.Enemy;
using h24s_15.Battle.GUI;
using h24s_15.Battle.GUI.Buttons;
using h24s_15.Battle.PlayerCharacter;
using h24s_15.Battle.Rolling;
using h24s_15.Buff;
using h24s_15.Utils;
using h24s_15.Utils.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3;
using Object = UnityEngine.Object;

namespace h24s_15.Battle.TurnBattleSystem {
    public class TurnBattleManager : SingletonMonoBehaviour<TurnBattleManager> {
        [SerializeField] private TurnEndButton _turnEndButton;
        [SerializeField] private DiceSetManager _diceSetManager;
        [SerializeField] private TurnBattleData _data;
        [SerializeField] private Image _overlayImage;
        [SerializeField] private TMP_Text _remainingTicketText;

        private readonly Subject<Unit> _onTurnEnded = new();
        public Observable<Unit> OnTurnEnded => _onTurnEnded;
        public TurnBattleData Data => _data;

        private bool _isTurnEnding = false;

        protected override void Awake() {
            base.Awake();

            _overlayImage.enabled = false;
            _data.CurrentPlayerCharacter = UnityObjectUtils.FindObjectByInterface<IPlayerCharacter>();
            _data.CurrentEnemies = UnityObjectUtils.FindObjectsByInterface<IEnemy>().ToList();
        }

        private void Start() {
            _data.RemainingOperateCount.Subscribe(ticketCount => {
                // 全角の数字にする.
                _remainingTicketText.text = ticketCount.ToString().ToFullNumber();
            }).AddTo(this);

            _turnEndButton.OnClicked.Subscribe(_ => { OnTurnEnd().Forget(); }).AddTo(this);

            _data.RemainingOperateCount
                .Where(count => count <= 0)
                .Subscribe(async _ => { await OnTurnEnd(); })
                .AddTo(this);

            _data.CurrentPlayerCharacter.OnDefeated.Subscribe(_ => { OnDefeated(); }).AddTo(this);

            var onDefeatAllEnemy = _data.CurrentEnemies[0].OnDefeated;
            for (var i = 1; i < _data.CurrentEnemies.Count; i++) {
                onDefeatAllEnemy = onDefeatAllEnemy.Zip(_data.CurrentEnemies[0].OnDefeated, (x, y) => Unit.Default);
            }

            onDefeatAllEnemy.Subscribe(_ => { OnDefeatAllEnemy(); }).AddTo(this);
        }

        private async UniTask OnTurnEnd() {
            if (_isTurnEnding) {
                Debug.LogError($"ターン遷移の途中でターンエンドをしようとしました");
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
            _onTurnEnded.OnNext(Unit.Default);
        }

        public async void OnDefeatAllEnemy() {
            Debug.Log($"敵を倒した！");
            BuffSelectManager.Instance.DisplayBuffSelect();
        }

        public async void OnDefeated() {
            _overlayImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            _overlayImage.enabled = true;
            Debug.Log("やられた！");
            _overlayImage.DOFade(1.0f, 1.0f);
        }
    }
}
