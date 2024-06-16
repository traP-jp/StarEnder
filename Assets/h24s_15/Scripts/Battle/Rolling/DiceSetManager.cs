using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using h24s_15.Battle.Actions;
using h24s_15.Battle.TurnBattleSystem;
using h24s_15.Buff;
using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public class DiceSetManager : SingletonMonoBehaviour<DiceSetManager> {
        [SerializeField] private HeadRollEyesSelector _headRollEyesSelector;
        [SerializeField] private DiceSet _diceSet;

        private List<Vector3> _initialPositions;

        protected override void Awake() {
            base.Awake();
            _initialPositions = _diceSet.Value.Select(dice => dice.transform.position).ToList();
        }

        public void ApplyDiffProbWeights(DiffProbWeights diffProbWeights) {
            _diceSet.CommonProbsWeights.ApplyDiff(diffProbWeights);
        }

        public void RollAll() {
            var result = _diceSet.Roll();
            var role = RollingUtils.EvaluateRole(result);

            var notLockedDices = _diceSet.Value.Where(dice => !dice.IsLocked.CurrentValue).ToList();
            var rolledLength = notLockedDices.Count;

            // 出目によってダイスの位置をソート.
            // indexと出目のどちらも保持しておく.
            var sortedResult = _diceSet.Value.Select((dice, index) => new { dice, index })
                .OrderBy(pair => pair.dice.CurrentUpRollEye).ToList();

            for (var index = 0; index < DiceSet.SET_SIZE; index++) {
                sortedResult[index].dice.transform.position = _initialPositions[index];
            }

            Debug.Log($"ダイスを{rolledLength}個振って「{string.Join(", ", result)}」が出ました。役は「{role.ToJapaneseText()}」です。");

            if (TurnBattleManager.Instance.Data.RemainingOperateCount.Value > 0) {
                TurnBattleManager.Instance.Data.RemainingOperateCount.Value--;
            }

            if (TurnBattleManager.Instance.Data.RemainingOperateCount.Value == 0) {
                TurnBattleManager.Instance.OnTurnEnd();
            }
        }

        public async void SubmitThisSet() {
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

            // アクションデータ.
            var actionDatList = new List<IActionData>();
            foreach (var headEye in resultHeadEyes) {
                var thisActionData = RollResultToActionConverter.Instance.GetActionData(headEye);
                actionDatList.Add(thisActionData);
            }

            var resultUnit = new DiceResultUnit(resultRollEyes, role, resultHeadEyes,
                RollResultToActionConverter.CompositeActionData(actionDatList));

            TurnBattleManager.Instance.Data.DiceHistory.AddHistory(resultUnit);

            TurnBattleManager.Instance.Data.RemainingOperateCount.Value--;

            if (TurnBattleManager.Instance.Data.RemainingOperateCount.Value == 0) {
                TurnBattleManager.Instance.OnTurnEnd();
            }
        }

        public async void SubmitThisSetAndRollAll() {
            SubmitThisSet();
            RollAll();
        }

        private async UniTask<List<RollEye>> DisplayHeadRollEyesSelector(Role role) {
            _headRollEyesSelector.EnableUnits();

            var selectedResult = await _headRollEyesSelector.SelectRollEye(role);

            _headRollEyesSelector.DisableUnits();

            return selectedResult;
        }
    }
}
