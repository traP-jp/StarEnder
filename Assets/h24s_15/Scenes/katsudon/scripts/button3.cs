using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button3 : MonoBehaviour
{
    private afterbutton NextKanri;

    // Start is called before the first frame update
    void Start()
    {
        NextKanri = GameObject.Find ("NextKanri").GetComponent<afterbutton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (NextKanri.buttonF == 0)
        {
            Debug.Log("３個目（右のやつ）が押されたよ");  // ログを出力
            NextKanri.buttonF = 3;
            NextKanri.downmove(GameObject.Find ("Button1"));
            NextKanri.downmove(GameObject.Find ("Button2"));
        }
    }

    public void OnMouseOver()
    {
        gameObject.transform.localScale = Vector3.one * 1.1f;
    }
    public void OnMouseExit()
    {
        gameObject.transform.localScale = Vector3.one;
    }
}
