using UnityEngine;
using UnityEngine.EventSystems;

namespace h24s_15.Battle.GUI {
    public class ScrollRectMaskWithWheel : MonoBehaviour, IScrollHandler {
        public RectTransform content; // ContentのRectTransformを設定
        public RectTransform maskArea; // RectMask2Dの範囲を設定するRectTransform
        public float scrollSpeed = 20f; // スクロール速度を調整する

        private void Start() {
            if (content == null) {
                Debug.LogError("Content RectTransform is not set.");
            }

            if (maskArea == null) {
                Debug.LogError("Mask Area RectTransform is not set.");
            }
        }

        public void OnScroll(PointerEventData eventData) {
            // マウスカーソルのスクリーン座標を取得
            Vector2 localMousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(maskArea, Input.mousePosition,
                eventData.pressEventCamera, out localMousePosition);

            // カーソルがマスクエリアの範囲内にあるかどうかをチェック
            var isPointerInside = maskArea.rect.Contains(localMousePosition);

            if (isPointerInside) {
                // マウスホイールのスクロール量を取得し、Y方向にスクロールする
                var scrollDelta = eventData.scrollDelta.y * scrollSpeed;
                content.anchoredPosition += new Vector2(0, scrollDelta);
            }
        }
    }
}
