using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public class RoleMultiplierManager : SingletonMonoBehaviour<RoleMultiplierManager> {
        [SerializeField] private RoleMultipliers _initialRoleMultiplier;
        [SerializeField] private RoleMultipliers _currentRoleMultiplier;

        public RoleMultipliers InitialRoleMultiplier => _initialRoleMultiplier;
        public RoleMultipliers CurrentRoleMultiplier => _currentRoleMultiplier;
    }
}
