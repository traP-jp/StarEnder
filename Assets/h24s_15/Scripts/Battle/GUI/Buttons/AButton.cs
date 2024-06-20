using R3;
using UnityEngine;
using UnityEngine.UI;

namespace h24s_15.Battle.GUI.Buttons {
    public class AButton : MonoBehaviour {
        protected Button _button;
        protected readonly ReactiveProperty<bool> _isInteractable = new(false);
        protected readonly Subject<Unit> _onClicked = new();
        public Observable<Unit> OnClicked => _onClicked;
        public bool IsInteractable => _isInteractable.Value;

        protected virtual void Awake() {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => {
                if (!_button.interactable) {
                    return;
                }

                _onClicked.OnNext(Unit.Default);
            });
        }

        public void SetInteractable(bool isInteractable) {
            _isInteractable.Value = isInteractable;
            _button.interactable = isInteractable;
        }
    }
}
