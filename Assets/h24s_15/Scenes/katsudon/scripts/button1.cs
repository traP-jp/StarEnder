using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1 : MonoBehaviour
{
    private afterbutton NextKanri;
    private bool supagethiF;
    // Start is called before the first frame update
    void Start()
    {
        NextKanri = GameObject.Find ("NextKanri").GetComponent<afterbutton>();

    }

    // Update is called once per frame
    void Update()
    {
        if (supagethiF)
        {
            transform.position = Vector3.MoveTowards(transform.position,new Vector2(0,+0), 3);
        }
    }

    public void OnClick()
    {
        if (NextKanri.buttonF == 0)
        {
            Debug.Log("一個目（左のやつ）が押されたよ");  // ログを出力
            NextKanri.buttonF = 1;
            NextKanri.downmove(GameObject.Find ("Button2"));
            NextKanri.downmove(GameObject.Find ("Button3"));
            gameObject.transform.localScale = Vector3.one;
            Invoke(nameof(MigiMove), 1.0f);

            Invoke(nameof(Checkappear1),1.5f);
        }
    }
    public void Checkappear1()
    {
        Debug.Log("kdsdjfoasjfadslfj");
        NextKanri.Checkappear();
    }

    public void MigiMove()
    {
        supagethiF = true;
    }
    public void OnMouseOver()
    {
        if (NextKanri.buttonF == 0)gameObject.transform.localScale = Vector3.one * 1.1f;
    }
    public void OnMouseExit()
    {
        gameObject.transform.localScale = Vector3.one;
    }
}
