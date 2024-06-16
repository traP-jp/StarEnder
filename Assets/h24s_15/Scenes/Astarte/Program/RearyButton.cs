using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RearyBotan : MonoBehaviour
{
    public GameManager gameManager;
    public AudioManager audioManager;

     public void OnClickRearyButton()
    {
        if (audioManager != null)
        {
            audioManager.PlaySE2();
            Debug.Log("ボタンがクリックされましたか？");
        }
        
        // ここにクリックに対する反応の処理を記述する
        gameManager.ClickAgain();
    // Start is called before the first frame update
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

