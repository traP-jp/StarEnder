using System.Collections.Generic;
using h24s_15.Battle.Rolling;
using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.Actions {
    public class RollResultToActionConverter : SingletonMonoBehaviour<RollResultToActionConverter> {
        [SerializeField] private List<ActionData> _rollEyeActionDataList;

        public IActionData GetActionData(RollEye rollEye) {
            return _rollEyeActionDataList[(int)rollEye - 1];
        }

        public static ActionData CompositeActionData(List<IActionData> dataList) {
            var singleAttackValue = 0;
            var singleShieldValue = 0;
            var consecutiveAttackValue = 0;
            var consecutiveAttackTurns = 0;
            var consecutiveShieldValue = 0;
            var consecutiveShieldTurns = 0;
            var singleSpecialEffect = SpecialEffectTypes.None;

            foreach (var data in dataList) {
                singleAttackValue += data.SingleAttackValue;
                singleShieldValue += data.SingleShieldValue;
                consecutiveAttackValue += data.ConsecutiveAttackValue;
                consecutiveAttackTurns += data.ConsecutiveAttackTurns;
                consecutiveShieldValue += data.ConsecutiveShieldValue;
                consecutiveShieldTurns += data.ConsecutiveShieldTurns;

                if (data.SingleSpecialEffect != SpecialEffectTypes.None) {
                    singleSpecialEffect = data.SingleSpecialEffect;
                }
            }

            return new ActionData(singleAttackValue, singleShieldValue, consecutiveAttackValue, consecutiveAttackTurns,
                consecutiveShieldValue, consecutiveShieldTurns, singleSpecialEffect);
        }
    }
}
