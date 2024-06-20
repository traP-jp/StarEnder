using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using h24s_15.Battle.GUI;
using h24s_15.Battle.GUI.Buttons;
using h24s_15.Battle.Rolling.Actions;
using h24s_15.Battle.TurnBattleSystem;
using h24s_15.Buff;
using UnityEngine;
using R3;

namespace h24s_15.Battle.Rolling {
    public class DiceSetManager : MonoBehaviour {
        [SerializeField] private CurrentRoleAndActionDisplay _currentRoleAndActionDisplay;
        [SerializeField] private DiceSubmitButton _diceSubmitButton;
        [SerializeField] private ReRollButton _reRollButton;
        [SerializeField] private HeadRollEyesSelector _headRollEyesSelector;
        [SerializeField] private DiceSet _diceSet;

        private List<Vector3> _initialPositions;

        protected void Awake() {
            _initialPositions = _diceSet.Value.Select(dice => dice.transform.position).ToList();
        }

        private void Start() {
            TurnBattleManager.Instance.OnTurnEnded.Subscribe(_ => { RollAll().Forget(); }).AddTo(this);

            _diceSubmitButton.OnClicked.Subscribe(async _ => {
                await SubmitThisSetAndRollAll();
                TurnBattleManager.Instance.Data.RemainingOperateCount.Value--;
            }).AddTo(this);

            _reRollButton.OnClicked.Subscribe(async _ => {
                await RollAll();
                TurnBattleManager.Instance.Data.RemainingOperateCount.Value--;
            }).AddTo(this);
        }

        public void ApplyDiffProbWeights(DiffProbWeights diffProbWeights) {
            _diceSet.CommonProbsWeights.ApplyDiff(diffProbWeights);
        }

        private async UniTask RollAll() {
            _reRollButton.SetInteractable(false);
            _diceSubmitButton.SetInteractable(false);

            var result = _diceSet.Roll();
            var role = RollingUtils.EvaluateRole(result);

            Array.Sort(result);

            var notLockedDices = _diceSet.Value.Where(dice => !dice.IsLocked.CurrentValue).ToList();
            var rolledLength = notLockedDices.Count;

            await UniTask.WhenAll(notLockedDices.Select(dice => dice.PlayRollAnimationAsync(dice.CurrentUpRollEye)));

            UnlockAllDices();
            SortDicePositionsByRollEyes();
            var resultUnit = new DiceResultUnit(result, role, RollingUtils.ComputeHeadEyes(result));
            _currentRoleAndActionDisplay.SetInfo(resultUnit);
            _reRollButton.SetInteractable(true);
            _diceSubmitButton.SetInteractable(true);

            Debug.Log($"ダイスを{rolledLength}個振って「{string.Join(", ", result)}」が出ました。役は「{role.ToJapaneseText()}」です。");
        }

        private void SortDicePositionsByRollEyes() {
            // 出目によってダイスの位置をソート.
            var sortedDices = _diceSet.Value.OrderBy(dice => dice.CurrentUpRollEye).ToList();

            for (var index = 0; index < DiceSet.SET_SIZE; index++) {
                sortedDices[index].transform.position = _initialPositions[index];
            }
        }

        private void UnlockAllDices() {
            foreach (var dice in _diceSet.Value) {
                dice.IsLocked.Value = false;
            }
        }

        private async UniTask SubmitThisSet() {
            _reRollButton.SetInteractable(false);
            _diceSubmitButton.SetInteractable(false);

            var resultRollEyes = _diceSet.Value.Select(dice => dice.CurrentUpRollEye).ToArray();
            Array.Sort(resultRollEyes);
            var role = RollingUtils.EvaluateRole(resultRollEyes);

            // 自分で選択する必要がある目が複数ある場合.
            var resultHeadEyes = new List<RollEye>();
            if (role.IsMultipleEyeNecessary()) {
                Debug.Log("出目の選択が必要なので選択フェイズに移行します");
                var selectedEyes = await DisplayHeadRollEyesSelector(role);
                resultHeadEyes.AddRange(selectedEyes);
            }
            else {
                var headEyes = RollingUtils.ComputeHeadEyes(resultRollEyes);
                resultHeadEyes.AddRange(headEyes);
            }

            var resultUnit = new DiceResultUnit(resultRollEyes, role, resultHeadEyes);

            TurnBattleManager.Instance.Data.DiceHistory.AddHistory(resultUnit);
            _reRollButton.SetInteractable(true);
            _diceSubmitButton.SetInteractable(true);
        }

        private async UniTask SubmitThisSetAndRollAll() {
            await SubmitThisSet();
            await RollAll();
        }

        private async UniTask<List<RollEye>> DisplayHeadRollEyesSelector(Role role) {
            _headRollEyesSelector.EnableUnits();

            var selectedResult = await _headRollEyesSelector.SelectRollEye(role);

            _headRollEyesSelector.DisableUnits();

            return selectedResult;
        }
    }
}
