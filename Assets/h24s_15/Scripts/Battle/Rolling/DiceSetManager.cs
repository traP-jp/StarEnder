using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using h24s_15.Battle.Actions;
using h24s_15.Battle.TurnBattleSystem;
using h24s_15.Buff;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public class DiceSetManager : MonoBehaviour {
        [SerializeField] private HeadRollEyesSelector _headRollEyesSelector;
        [SerializeField] private DiceSet _diceSet;

        public void ApplyDiffProbWeights(DiffProbWeights diffProbWeights) {
            _diceSet.CommonProbsWeights.ApplyDiff(diffProbWeights);
        }

        public void RollAll() {
            var result = _diceSet.Roll();
            var role = RollingUtils.EvaluateRole(result);

            var notLockedDices = _diceSet.Value.Where(dice => !dice.IsLocked.CurrentValue).ToList();
            var rolledLength = notLockedDices.Count;

            Debug.Log($"ダイスを{rolledLength}個振って「{string.Join(", ", result)}」が出ました。役は「{role.ToJapaneseText()}」です。");

            if (TurnBattleManager.Instance.Data.RemainingOperateCount.Value > 0) {
                TurnBattleManager.Instance.Data.RemainingOperateCount.Value--;
            }

            if (TurnBattleManager.Instance.Data.RemainingOperateCount.Value == 0) {
                TurnBattleManager.Instance.OnTurnEnd();
            }
        }

        public async UniTask SubmitThisSet() {
            var resultRollEyes = _diceSet.Value.Select(dice => dice.CurrentUpRollEye).ToArray();
            System.Array.Sort(resultRollEyes);
            var role = RollingUtils.EvaluateRole(resultRollEyes);

            // 自分で選択する必要がある目が複数ある場合.
            var resultHeadEyes = new List<RollEye>();
            if (role.IsMultipleEyeNecessary()) {
                Debug.Log("出目の選択が必要なので選択フェイズに移行します");
                var selectedEyes = await DisplayHeadRollEyesSelector(role, resultRollEyes);
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
        }

        public async void SubmitThisSetAndRollAll() {
            await SubmitThisSet();
            RollAll();
        }

        private async UniTask<List<RollEye>> DisplayHeadRollEyesSelector(Role role, RollEye[] eyes) {
            _headRollEyesSelector.SetRollEyes(eyes);
            _headRollEyesSelector.EnableUnits();

            _headRollEyesSelector.gameObject.SetActive(true);
            var selectedResult = await _headRollEyesSelector.SelectRollEye(role);
            _headRollEyesSelector.gameObject.SetActive(false);

            _headRollEyesSelector.DisableUnits();

            return selectedResult;
        }
    }
}
