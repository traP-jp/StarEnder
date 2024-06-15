using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;
    public GameObject canvas6;
    public GameManager gameManager;

    void Start()
    {

    }

    void Update()
    {
        if(gameManager.progress == 1){
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
        canvas6.SetActive(false);
        }
        else if(gameManager.progress==2){
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
        canvas6.SetActive(false);
        }
        else if(gameManager.progress==3){
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(true);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
        canvas6.SetActive(false);
        }else if(gameManager.progress==4){
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        canvas5.SetActive(false);
        canvas6.SetActive(false);
        }else if(gameManager.progress==5){
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(true);
        canvas6.SetActive(false);
        }else if(gameManager.progress==6){
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
        canvas6.SetActive(true);
        }
    }
}