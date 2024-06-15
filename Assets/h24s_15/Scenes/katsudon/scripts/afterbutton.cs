using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterbutton : MonoBehaviour
{
    public int buttonF;
    public GameObject selectcheck;
    // Start is called before the first frame update
    void Start()
    {
        selectcheck = GameObject.Find("SelectCheck");
        selectcheck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void upmove(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1000));
    }
    public void downmove(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-1000));
    }

    public void Checkappear()
    {
        selectcheck.SetActive(true);
    }
}
