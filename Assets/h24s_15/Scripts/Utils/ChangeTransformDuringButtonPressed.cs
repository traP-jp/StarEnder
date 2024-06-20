using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace h24s_15.Utils {
    public class ChangeTransformDuringButtonPressed : MonoBehaviour {
        [SerializeField] private Button _button;

        [Header("パラメーター")]
        [SerializeField] private Vector3 _diffPosition;

        [SerializeField] private Vector3 _diffRotation;
        [SerializeField] private Vector3 _diffScale;

        private bool _existsButton = false;

        private Vector3 _initialPosition;
        private Vector3 _initialRotation;
        private Vector3 _initialScale;

        private void Awake() {
            _existsButton = _button != null;

            _initialPosition = transform.localPosition;
            _initialRotation = transform.localEulerAngles;
            _initialScale = transform.localScale;

            if (!_existsButton) {
                return;
            }

            // EventTriggerコンポーネントをボタンに追加
            var trigger = _button.gameObject.AddComponent<EventTrigger>();

            // ボタンが押されたときのイベントを設定
            var pointerDownEntry = new EventTrigger.Entry {
                eventID = EventTriggerType.PointerDown
            };
            pointerDownEntry.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
            trigger.triggers.Add(pointerDownEntry);

            // ボタンが離されたときのイベントを設定
            var pointerUpEntry = new EventTrigger.Entry {
                eventID = EventTriggerType.PointerUp
            };
            pointerUpEntry.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
            trigger.triggers.Add(pointerUpEntry);
        }

        // ボタンが押されたときに呼ばれる
        private void OnPointerDown(PointerEventData data) {
            if (_existsButton && _button.interactable) {
                ApplyForTransform();
            }
        }

        // ボタンが離されたときに呼ばれる
        private void OnPointerUp(PointerEventData data) {
            if (_existsButton) {
                ResetForTransform();
            }
        }

        private void ApplyForTransform() {
            transform.localPosition = _initialPosition + _diffPosition;
            transform.localEulerAngles = _initialRotation + _diffRotation;
            transform.localScale = _initialScale + _diffScale;
        }

        private void ResetForTransform() {
            transform.localPosition = _initialPosition;
            transform.localEulerAngles = _initialRotation;
            transform.localScale = _initialScale;
        }
    }
}
