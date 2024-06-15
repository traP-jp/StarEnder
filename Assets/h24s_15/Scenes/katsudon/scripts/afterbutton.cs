using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterbutton : MonoBehaviour
{
    public int buttonF;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (buttonF != 0)
        {
            Debug.Log("iine");
        }
        
    }

    public void upmove(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1000));
    }
    public void downmove(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-1000));
    }
}
