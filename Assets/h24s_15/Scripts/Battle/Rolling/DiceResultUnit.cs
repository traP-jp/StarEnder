using System.Collections.Generic;
using h24s_15.Battle.Rolling.Actions;

namespace h24s_15.Battle.Rolling {
    public record DiceResultUnit {
        public readonly RollEye[] SortedEyes;
        public readonly Role Role;
        public readonly List<RollEye> HeadEyes;

        private IActionData _actionData;

        public IActionData ActionData {
            get {
                if (_actionData == null) {
                    _actionData = ComputeActionData();
                }

                return _actionData;
            }
        }

        private IActionData ComputeActionData() {
            // アクションデータ.
            var actionDatList = new List<IActionData>();
            foreach (var headEye in HeadEyes) {
                var thisActionData = RollResultToActionConverter.Instance.GetActionData(headEye).ApplyRoleInfo(Role);
                actionDatList.Add(thisActionData);
            }

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
