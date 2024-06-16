using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botan : MonoBehaviour
{
    public RearyBotan rearyBotan;
     public AudioManager audioManager;

     public void OnClickButton()
    {
         if (audioManager != null)
        {
            audioManager.PlaySE2();
            Debug.Log("ボタンがクリックされました！");
        }
        
        // ここにクリックに対する反応の処理を記述する
        rearyBotan.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}