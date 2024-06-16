using System;
using System.Collections.Generic;
using System.Linq;
using h24s_15.Battle.Actions;
using h24s_15.Battle.Rolling;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace h24s_15.Battle.GUI {
    public class DiceHistoryUnit : MonoBehaviour {
        [SerializeField] private GameObject _content1Parent;
        [SerializeField] private GameObject _content2Parent;

        [SerializeField] private List<Image> _contentDiceImages;
        [SerializeField] private Image _contentRoleImage;
        [SerializeField] private List<Image> _contentActionTypeImage;
        [SerializeField] private List<TMP_Text> _contentActionValueText;

        [Header("パラメーター")]
        [Tooltip("内容1と2の切り替え秒数")] [SerializeField] private float _switchContentSeconds = 1.0f;

        private float _switchContentTimer = 0.0f;

        private void Awake() {
            _content1Parent.SetActive(true);
            _content2Parent.SetActive(false);

            foreach (var image in _contentActionTypeImage) {
                image.gameObject.SetActive(false);
            }

            foreach (var text in _contentActionValueText) {
                text.gameObject.SetActive(false);
            }
        }

        public void Initialize(DiceResultUnit resultUnit) {
            var sprites = resultUnit.SortedEyes.Select(eye => eye.ToHistorySprite()).ToArray();
            for (var index = 0; index < DiceSet.SET_SIZE; index++) {
                _contentDiceImages[index].sprite = sprites[index];
            }

            _contentRoleImage.sprite = resultUnit.Role.ToSprite();
            var actionData = resultUnit.ActionData;
            var actionTypes = actionData.GetActionTypes();
            for (var i = 0; i < actionTypes.Count; i++) {
                var thisActionData = actionTypes[i];
                _contentActionTypeImage[i].sprite = thisActionData.ToSprite();
                _contentActionTypeImage[i].gameObject.SetActive(true);

                var actionValue = resultUnit.ActionData.GetActionValue(actionTypes[i]);
                _contentActionValueText[i].text = actionValue is 0 ? "" : actionValue.ToString();
                _contentActionValueText[i].gameObject.SetActive(true);
            }
        }

        private void Update() {
            _switchContentTimer += Time.deltaTime;
            if (_switchContentTimer >= _switchContentSeconds) {
                _switchContentTimer = 0.0f;
                SwitchContent();
            }
        }


        private void SwitchContent() {
            _content1Parent.SetActive(!_content1Parent.activeSelf);
            _content2Parent.SetActive(!_content2Parent.activeSelf);
        }
    }
}
