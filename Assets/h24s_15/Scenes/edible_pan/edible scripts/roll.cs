using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject objectToDestroy; // 消したいオブジェクトをインスペクタで指定
    
    
    void Start()
    {
        // ボタンがクリックされたときにDestroyObjectメソッドを呼び出す
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(DestroyObject);

        
    }

    void DestroyObject()
    {
        // オブジェクトを破棄する
        Destroy(objectToDestroy);
        Debug.Log("サイコロを振った");
    

        
    }
}
