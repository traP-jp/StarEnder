using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public int progress = 1;
    
    public GameObject RearyButton1;
    public GameObject Button1;
     public GameObject RearyButton2;
    public GameObject Button2;
    public GameObject RearyButton3;
    public GameObject Button3;
     public GameObject RearyButton4;
    public GameObject Button4;
    public GameObject RearyButton5;
    public GameObject Button5;
     public GameObject RearyButton6;
    public GameObject Button6;
    private void Start()
    {
    RearyButton1.gameObject.SetActive(false);
    
    Button1.gameObject.SetActive(true);
    RearyButton2.gameObject.SetActive(false);
    
    Button2.gameObject.SetActive(true);
    RearyButton3.gameObject.SetActive(false);
    
    Button3.gameObject.SetActive(true);
    RearyButton4.gameObject.SetActive(false);
    
    Button4.gameObject.SetActive(true);
    RearyButton5.gameObject.SetActive(false);
    
    Button5.gameObject.SetActive(true);
    RearyButton6.gameObject.SetActive(false);
    
    Button6.gameObject.SetActive(true);
    }  

    public void ClickAgain()
    {
    RearyButton1.gameObject.SetActive(false);

    Button1.gameObject.SetActive(false);
    RearyButton2.gameObject.SetActive(false);

    Button2.gameObject.SetActive(false);
    RearyButton3.gameObject.SetActive(false);

    Button3.gameObject.SetActive(false);
    RearyButton4.gameObject.SetActive(false);

    Button4.gameObject.SetActive(false);
    RearyButton5.gameObject.SetActive(false);

    Button5.gameObject.SetActive(false);
    RearyButton6.gameObject.SetActive(false);

    Button6.gameObject.SetActive(false);
    }
    
}
