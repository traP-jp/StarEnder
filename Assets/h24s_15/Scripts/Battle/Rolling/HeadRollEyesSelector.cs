using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public class HeadRollEyesSelector : MonoBehaviour {
        [SerializeField] private List<RollEyeSelectorUnit> _rollEyeSelectorUnits;

        public async UniTask<List<RollEye>> SelectRollEye(Role role) {
            var necessarySelectCount = role switch {
                Role.SStraight => 2,
                Role.BStraight => 4,
                _ => throw new System.ArgumentException($"Role {role} is not supported.")
            };
            await UniTask.WaitUntil(() => GetSelectedCount() == necessarySelectCount);

            return (from unit in _rollEyeSelectorUnits where unit.IsSelected.CurrentValue select unit.RollEye).ToList();
        }

        private int GetSelectedCount() {
            return _rollEyeSelectorUnits.Count(unit => unit.IsSelected.CurrentValue);
        }
    }
}
