using System.Collections.Generic;

namespace h24s_15.Battle.Rolling.Actions {
    public interface IActionData {
        public int SingleAttackValue { get; }
        public int SingleShieldValue { get; }
        public int ConsecutiveAttackValue { get; }
        public int ConsecutiveAttackTurns { get; }
        public int ConsecutiveShieldValue { get; }
        public int ConsecutiveShieldTurns { get; }
        public SpecialEffectTypes SingleSpecialEffect { get; }

        public IReadOnlyList<ActionTypes> GetActionTypes();
        public int? GetActionValue(ActionTypes actionType);
        public IActionData ApplyRoleMultiplier(Role role);
        public IActionData Append(IActionData actionData);
        public IActionData Append(List<IActionData> actionDataList);
    }
}
