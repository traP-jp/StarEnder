using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameManager gameManager;

    void Start()
    {

    }

    void Update()
    {
        if(gameManager.progress == 1){
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        }
        else if(gameManager.progress==2){
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        }
    }
}

