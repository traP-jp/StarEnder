using h24s_15.Battle.Actions;
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

        public void SetInfo(RoleAndActionData roleAndActionData) {
            _roleImage.sprite = roleAndActionData.Role.ToSprite();

            var actionType1 = roleAndActionData.ActionData.GetActionTypes()[0];
            _actionTypeImage1.sprite = actionType1.ToSprite();
            _actionValueText1.text = roleAndActionData.ActionData.GetActionValue(actionType1).ToString();

            var actionType2 = roleAndActionData.ActionData.GetActionTypes()[1];
            _actionTypeImage2.sprite = actionType2.ToSprite();
            _actionValueText2.text = roleAndActionData.ActionData.GetActionValue(actionType2).ToString();
        }
    }
}
