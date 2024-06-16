using R3;
using UnityEngine;
using UnityEngine.EventSystems;

namespace h24s_15.Battle.Rolling {
    public class RollEyeSelectorUnit : MonoBehaviour, IPointerDownHandler {
        [SerializeField] private RollEye _rollEye;
        private readonly ReactiveProperty<bool> _isSelected = new(false);

        public ReadOnlyReactiveProperty<bool> IsSelected => _isSelected.ToReadOnlyReactiveProperty();

        public RollEye RollEye => _rollEye;

        public void OnPointerDown(PointerEventData eventData) {
            _isSelected.Value = true;
        }
    }
}
