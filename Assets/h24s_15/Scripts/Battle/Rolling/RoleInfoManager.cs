using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public class RoleInfoManager : SingletonMonoBehaviour<RoleInfoManager> {
        [SerializeField] private RoleMultipliers _currentRoleMultipliers;

        public RoleMultipliers CurrentRoleMultipliers => _currentRoleMultipliers;
    }
}
