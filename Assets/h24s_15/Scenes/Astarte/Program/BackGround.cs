using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    
    public int back1;
    public int back2;
    public int back3;
    public int back4;
    public int back5;
    public int back6;
    public int back7;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(gameManager.progress == 1){
        if(back1==1){
            background1.SetActive(true);
            background2.SetActive(false);
            background3.SetActive(false);
        }
        if(back1==2){
            background2.SetActive(true);
            background1.SetActive(false);
            background3.SetActive(false);
        }
        if(back1==3){
            background3.SetActive(true);
            background1.SetActive(false);
            background2.SetActive(false);
        }
        } 
        if(gameManager.progress == 2){
        if(back2==1){
            background1.SetActive(true);
            background2.SetActive(false);
            background3.SetActive(false);
        }
        if(back2==2){
            background2.SetActive(true);
            background1.SetActive(false);
            background3.SetActive(false);
        }
        if(back2==3){
            background3.SetActive(true);
            background1.SetActive(false);
            background2.SetActive(false);
        }
        } 
        if(gameManager.progress == 3){
        if(back3==1){
            background1.SetActive(true);
            background2.SetActive(false);
            background3.SetActive(false);
        }
        if(back3==2){
            background2.SetActive(true);
            background1.SetActive(false);
            background3.SetActive(false);
        }
        if(back3==3){
            background3.SetActive(true);
            background1.SetActive(false);
            background2.SetActive(false);
        }
        } 
        if(gameManager.progress == 4){
        if(back4==1){
            background1.SetActive(true);
            background2.SetActive(false);
            background3.SetActive(false);
        }
        if(back4==2){
            background2.SetActive(true);
            background1.SetActive(false);
            background3.SetActive(false);
        }
        if(back4==3){
            background3.SetActive(true);
            background1.SetActive(false);
            background2.SetActive(false);
        }
        } 
        if(gameManager.progress == 5){
        if(back5==1){
            background1.SetActive(true);
            background2.SetActive(false);
            background3.SetActive(false);
        }
        if(back5==2){
            background2.SetActive(true);
            background1.SetActive(false);
            background3.SetActive(false);
        }
        if(back5==3){
            background3.SetActive(true);
            background1.SetActive(false);
            background2.SetActive(false);
        }
        } 
        if(gameManager.progress == 6){
        if(back6==1){
            background1.SetActive(true);
            background2.SetActive(false);
            background3.SetActive(false);
        }
        if(back6==2){
            background2.SetActive(true);
            background1.SetActive(false);
            background3.SetActive(false);
        }
        if(back6==3){
            background3.SetActive(true);
            background1.SetActive(false);
            background2.SetActive(false);
        }
        } 
        if(gameManager.progress == 7){
        if(back7==1){
            background1.SetActive(true);
            background2.SetActive(false);
            background3.SetActive(false);
        }
        if(back7==2){
            background2.SetActive(true);
            background1.SetActive(false);
            background3.SetActive(false);
        }
        if(back7==3){
            background3.SetActive(true);
            background1.SetActive(false);
            background2.SetActive(false);
        }
        } 
    }
}
