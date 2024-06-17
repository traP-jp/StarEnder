using System.Collections.Generic;
using h24s_15.Battle.Actions;
using h24s_15.Battle.Rolling.Actions;

namespace h24s_15.Battle.Rolling {
    public readonly struct DiceResultUnit {
        public readonly RollEye[] SortedEyes;
        public readonly Role Role;
        public readonly List<RollEye> HeadEyes;
        public readonly IActionData ActionData;

        public DiceResultUnit(RollEye[] sortedEyes, Role role, List<RollEye> headEyes, IActionData actionData) {
            SortedEyes = sortedEyes;
            Role = role;
            HeadEyes = headEyes;
            ActionData = actionData;
        }
    }
}
