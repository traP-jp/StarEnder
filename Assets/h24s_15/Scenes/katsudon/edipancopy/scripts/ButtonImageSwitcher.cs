using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonImageSwitcher : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalImage; // 通常状態の画像
    public Sprite pressedImage; // 押している状態の画像

    private Image buttonImage; // ボタンのImageコンポーネント

    void Start()
    {
        buttonImage = GetComponent<Image>();

        // 初期状態の画像をセット
        if (buttonImage != null)
        {
            buttonImage.sprite = normalImage;
        }
    }

    // ボタンが押されたときに呼び出される
    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = pressedImage;
        }
    }

    // ボタンが離されたときに呼び出される
    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = normalImage;
        }
    }
}
