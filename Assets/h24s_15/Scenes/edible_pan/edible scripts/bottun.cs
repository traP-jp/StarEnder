using UnityEngine;
using UnityEngine.Events;

namespace h24s_15.Scenes.edible_pan.edible_scripts {
    public class ClickToDisappearAndReappear : MonoBehaviour {
        private bool isClicked = false; // クリックされたかどうかのフラグ
        private Renderer objectRenderer; // オブジェクトのレンダラー
        private float disappearTime = 0.5f; // オブジェクトが消える時間（秒）

        [SerializeField] private UnityEvent onDisappear; // オブジェクトが消えたときに呼び出すイベント

        private void Start() {
            objectRenderer = GetComponent<Renderer>(); // オブジェクトのレンダラーを取得する
        }

        private void Update() {
            // クリックされたらオブジェクトを非表示にする
            if (isClicked) {
                objectRenderer.enabled = false; // オブジェクトを非表示にする
                Invoke(nameof(ReappearObject), disappearTime); // disappearTime 秒後にオブジェクトを再表示する
                isClicked = false; // フラグをリセットする
            }
        }

        private void OnMouseDown() {
            isClicked = true; // クリックされたらフラグを立てる
            onDisappear.Invoke(); // オブジェクトが消えたときに呼び出すイベントを実行する
        }

        private void ReappearObject() {
            objectRenderer.enabled = true; // オブジェクトを再表示する
        }
    }
}
