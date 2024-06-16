using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public class HeadRollEyesSelector : MonoBehaviour {
        [SerializeField] private List<RollEyeSelectorUnit> _rollEyeSelectorUnits;
        [SerializeField] private TMP_Text _selectDescriptionText;

        private void Awake() {
            DisableUnits();
            _selectDescriptionText.enabled = false;
        }

        public void DisableUnits() {
            foreach (var unit in _rollEyeSelectorUnits) {
                unit.IsEnabled = false;
            }
        }

        public void EnableUnits() {
            foreach (var unit in _rollEyeSelectorUnits) {
                unit.IsEnabled = true;
            }
        }

        public void ResetColors() {
            foreach (var unit in _rollEyeSelectorUnits) {
                unit.ResetColor();
            }
        }

        public async UniTask<List<RollEye>> SelectRollEye(Role role) {
            var necessarySelectCount = role switch {
                Role.SStraight => 2,
                Role.BStraight => 4,
                _ => throw new ArgumentException($"Role {role} is not supported.")
            };

            _selectDescriptionText.text = $"出目を{necessarySelectCount}種類選んでください";
            _selectDescriptionText.enabled = true;
            await UniTask.WaitUntil(() => GetSelectedCount() == necessarySelectCount);
            _selectDescriptionText.enabled = false;

            Debug.Log($"出目を選択し終わりました");
            ResetColors();
            var selectedEyes = (from unit in _rollEyeSelectorUnits
                where unit.IsSelected.CurrentValue
                select unit.Dice.CurrentUpRollEye).ToList();

            Array.Sort(selectedEyes.ToArray());
            return selectedEyes;
        }

        private int GetSelectedCount() {
            return _rollEyeSelectorUnits.Count(unit => unit.IsSelected.CurrentValue);
        }
    }
}
