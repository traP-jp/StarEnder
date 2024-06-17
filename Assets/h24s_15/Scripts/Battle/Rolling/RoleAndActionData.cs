using h24s_15.Battle.Rolling.Actions;

namespace h24s_15.Battle.Rolling {
    public readonly struct RoleAndActionData {
        public IActionData ActionData { get; }

        public Role Role { get; }

        public RoleAndActionData(Role role, IActionData actionData) {
            Role = role;
            ActionData = actionData;
        }
    }
}
