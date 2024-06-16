using System;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace h24s_15.Battle.Rolling {
    public class RollEyeSelectorUnit : MonoBehaviour, IPointerClickHandler {
        [SerializeField] private Image _diceFrameImage;
        [SerializeField] private Dice _dice;

        [HideInInspector] public bool IsEnabled = false;
        private readonly ReactiveProperty<bool> _isSelected = new(false);

        public Dice Dice => _dice;
        public ReadOnlyReactiveProperty<bool> IsSelected => _isSelected.ToReadOnlyReactiveProperty();

        private void Awake() {
            IsEnabled = false;
        }

        public void ResetColor() {
            _diceFrameImage.color = Color.white;
        }

        public void OnPointerClick(PointerEventData eventData) {
            if (!IsEnabled) {
                return;
            }

            _diceFrameImage.color = Color.red;
            _isSelected.Value = true;
            IsEnabled = false;
            Debug.Log($"{_dice.CurrentUpRollEye}が選ばれました");
        }
    }
}
