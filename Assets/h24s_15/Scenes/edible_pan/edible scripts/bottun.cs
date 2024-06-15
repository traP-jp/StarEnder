using UnityEngine;

public class ClickToDisappearAndReappear : MonoBehaviour
{
    private bool isClicked = false; // クリックされたかどうかのフラグ
    private Renderer objectRenderer; // オブジェクトのレンダラー
    private float disappearTime = 0.5f; // オブジェクトが消える時間（秒）

    void Start()
    {
        objectRenderer = GetComponent<Renderer>(); // オブジェクトのレンダラーを取得する
    }

    void Update()
    {
        // クリックされたらオブジェクトを非表示にする
        if (isClicked)
        {
            objectRenderer.enabled = false; // オブジェクトを非表示にする
            Invoke("ReappearObject", disappearTime); // disappearTime 秒後にオブジェクトを再表示する
            isClicked = false; // フラグをリセットする
        }
    }

    void OnMouseDown()
    {
        isClicked = true; // クリックされたらフラグを立てる
    }

    void ReappearObject()
    {
        objectRenderer.enabled = true; // オブジェクトを再表示する
    }
}
