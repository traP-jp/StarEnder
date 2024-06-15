using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 defaultScale;
    public float hoverScaleMultiplier = 1.1f; // ホバー時の拡大倍率

    void Start()
    {
        // ボタンの初期スケールを保持
        defaultScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // マウスがボタンに入った時の処理
        transform.localScale = defaultScale * hoverScaleMultiplier;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // マウスがボタンから出た時の処理
        transform.localScale = defaultScale; // 元のスケールに戻す
    }
}
