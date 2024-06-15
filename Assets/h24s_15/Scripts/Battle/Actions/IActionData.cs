using System.Collections.Generic;
using h24s_15.Battle.Rolling;

namespace h24s_15.Battle.Actions {
    public interface IActionData {
        public int SingleAttackValue { get; }
        public int SingleShieldValue { get; }
        public int ConsecutiveAttackValue { get; }
        public int ConsecutiveAttackTurns { get; }
        public int ConsecutiveShieldValue { get; }
        public int ConsecutiveShieldTurns { get; }
        public SpecialEffectTypes SingleSpecialEffect { get; }

        public IReadOnlyList<ActionTypes> GetActionTypes();
        public int GetActionValue(ActionTypes actionType);
    }
}
