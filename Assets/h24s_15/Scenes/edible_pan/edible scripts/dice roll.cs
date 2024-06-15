using System.Collections;
using UnityEngine;

public class RandomObjectSelector : MonoBehaviour
{
        public GameObject[] objectsToChooseFrom; // 選択肢となるオブジェクトの配列

    void Start()
    {
        int randomIndex = Random.Range(0, objectsToChooseFrom.Length); // ランダムなインデックスを取得
        GameObject selectedObject = objectsToChooseFrom[randomIndex]; // ランダムに選ばれたオブジェクトを取得

        // 選ばれたオブジェクトをアクティブにする（表示する）
        selectedObject.SetActive(true);
    }
}
