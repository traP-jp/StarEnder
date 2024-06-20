using System.Collections.Generic;
using System.Linq;
using h24s_15.Battle.Rolling.Actions;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public record DiceResultUnit {
        public readonly RollEye[] SortedEyes;
        public readonly Role Role;
        public readonly List<RollEye> HeadEyes;

        private IActionData _actionData;

        public IActionData ActionData => _actionData ??= ComputeActionData();

        private IActionData ComputeActionData() {
            // アクションデータ.
            var actionDatList = HeadEyes.Select(headEye =>
                RollResultToActionConverter.Instance.GetClonedActionData(headEye).ApplyRoleMultiplier(Role)).ToList();

            var resultActionData = RollResultToActionConverter.CompositeActionData(actionDatList);

            return resultActionData;
        }

        public DiceResultUnit(RollEye[] sortedEyes, Role role, List<RollEye> headEyes) {
            SortedEyes = sortedEyes;
            Role = role;
            HeadEyes = headEyes;
        }
    }
}
