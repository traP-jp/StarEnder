using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rolemanager : MonoBehaviour
{
    private Animator m_Animator = null;
    public GameObject dice1;
    public GameObject dice2;
    public GameObject dice3;
    public GameObject dice4;
    public GameObject dice5;

    rolestartt ddice1;
    rolestartt ddice2;
    rolestartt ddice3;
    rolestartt ddice4;
    rolestartt ddice5;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        ddice1 = dice1.GetComponent<rolestartt>();
        ddice2 = dice2.GetComponent<rolestartt>();
        ddice3 = dice3.GetComponent<rolestartt>();
        ddice4 = dice4.GetComponent<rolestartt>();
        ddice5 = dice5.GetComponent<rolestartt>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        ddice1.Rolestart();
        ddice2.Rolestart();
        ddice3.Rolestart();
        ddice4.Rolestart();
        ddice5.Rolestart();
    }

}
