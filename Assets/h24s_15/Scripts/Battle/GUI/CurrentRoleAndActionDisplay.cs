using System;
using h24s_15.Battle.Rolling;
using h24s_15.Battle.Rolling.Actions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace h24s_15.Battle.GUI {
    public class CurrentRoleAndActionDisplay : MonoBehaviour {
        [SerializeField] private Image _roleImage;
        [SerializeField] private Image _actionTypeImage1;
        [SerializeField] private TMP_Text _actionValueText1;
        [SerializeField] private Image _actionTypeImage2;
        [SerializeField] private TMP_Text _actionValueText2;

        private void Awake() {
            _actionTypeImage1.gameObject.SetActive(false);
            _actionValueText1.gameObject.SetActive(false);
            _actionTypeImage2.gameObject.SetActive(false);
            _actionValueText2.gameObject.SetActive(false);
        }

        public void SetInfo(DiceResultUnit resultUnit) {
            var role = resultUnit.Role;
            _roleImage.sprite = role.ToSprite();

            var actionData = resultUnit.ActionData;

            var actionCount = actionData.GetActionTypes().Count;

            if (actionCount == 0) {
                _actionTypeImage1.gameObject.SetActive(false);
                _actionValueText1.gameObject.SetActive(false);
                return;
            }

            _actionTypeImage1.gameObject.SetActive(true);
            _actionValueText1.gameObject.SetActive(true);

            var actionType1 = actionData.GetActionTypes()[0];
            _actionTypeImage1.sprite = actionType1.ToSprite();
            _actionValueText1.text = role.IsMultipleEyeNecessary()
                ? "？"
                : actionData.GetActionValue(actionType1).ToString();

            if (actionCount == 1) {
                _actionTypeImage2.gameObject.SetActive(false);
                _actionValueText2.gameObject.SetActive(false);
                return;
            }

            _actionTypeImage1.gameObject.SetActive(true);
            _actionValueText1.gameObject.SetActive(true);

            var actionType2 = actionData.GetActionTypes()[1];
            _actionTypeImage2.sprite = actionType2.ToSprite();
            _actionValueText2.text = role.IsMultipleEyeNecessary()
                ? "？"
                : actionData.GetActionValue(actionType2).ToString();
        }
    }
}
