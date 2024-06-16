using System;
using UnityEngine;

namespace h24s_15.Battle.GUI {
    public class RoleInfoDisplayer : MonoBehaviour {
        [SerializeField] private GameObject _overLay;
        [SerializeField] private GameObject _roleInfoPanel;

        private void Awake() {
            _overLay.SetActive(false);
            _roleInfoPanel.SetActive(false);
        }

        public void ToggleDisplayingRoleInfo() {
            _overLay.SetActive(!_overLay.activeSelf);
            _roleInfoPanel.SetActive(!_roleInfoPanel.activeSelf);
        }
    }
}
