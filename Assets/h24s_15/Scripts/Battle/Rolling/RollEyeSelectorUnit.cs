using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace h24s_15.Battle.Rolling {
    public class RollEyeSelectorUnit : MonoBehaviour, IPointerDownHandler {
        [SerializeField] private Image _diceFrameImage;

        public RollEye RollEye;
        private readonly ReactiveProperty<bool> _isSelected = new(false);

        public ReadOnlyReactiveProperty<bool> IsSelected => _isSelected.ToReadOnlyReactiveProperty();

        public void ResetColor() {
            _diceFrameImage.color = Color.white;
        }

        public void OnPointerDown(PointerEventData eventData) {
            _diceFrameImage.color = Color.red;
            _isSelected.Value = true;
            Debug.Log($"{RollEye}が選ばれました");
        }
    }
}
