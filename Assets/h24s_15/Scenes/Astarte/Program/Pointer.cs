using UnityEngine;
using UnityEngine.UI;

public class ImageMover : MonoBehaviour
{
    public RectTransform imageTransform; // 移動させたい画像のRectTransform
    private Vector3 startPos; // 初期位置
    private Vector3 targetPos; // 目標位置
    private bool movingUp = true; // 上下移動フラグ
    private float moveTime = 0.7f; // 移動にかかる時間
    private float timer = 0f;

    void Start()
    {
        if (imageTransform == null)
        {
            imageTransform = GetComponent<RectTransform>();
        }
        startPos = imageTransform.localPosition; // 初期位置を保存
        targetPos = new Vector3(startPos.x, startPos.y + 3, startPos.z); // 目標位置を設定
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            // タイマーリセット
            timer = 0f;
            // 移動方向を逆に
            movingUp = !movingUp;
            // 目標位置を更新
            targetPos = movingUp ? new Vector3(startPos.x, startPos.y + 3, startPos.z) : startPos;
        }

        // 位置を更新しながら滑らかに移動
        imageTransform.localPosition = Vector3.Lerp(imageTransform.localPosition, targetPos, timer / moveTime);
    }
}