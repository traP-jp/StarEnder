using h24s_15.Battle.Actions;

namespace h24s_15.Battle.Rolling {
    public readonly struct DiceResultUnit {
        public readonly RollEye[] SortedEyes;
        public readonly Role Role;
        public readonly RollEye SelectedEye;
        public readonly IActionData ActionData;

        public DiceResultUnit(RollEye[] sortedEyes, Role role, RollEye selectedEye, IActionData actionData) {
            SortedEyes = sortedEyes;
            Role = role;
            SelectedEye = selectedEye;
            ActionData = actionData;
        }
    }
}
