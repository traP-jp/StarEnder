using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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
    public GameObject RearyButton7;
    public GameObject Button7;
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;
    public GameObject canvas6;
    public GameObject canvas7;
    public GameObject background;
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
    RearyButton7.gameObject.SetActive(false);
    
    Button7.gameObject.SetActive(true);
    }  

    public void ClickAgain()
    {
        foreach (Transform child in canvas1.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in canvas2.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in canvas3.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in canvas4.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in canvas5.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in canvas6.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in canvas7.transform)
        {
            child.gameObject.SetActive(false);
        }
        
        background.gameObject.SetActive(false);
    }
    
}
