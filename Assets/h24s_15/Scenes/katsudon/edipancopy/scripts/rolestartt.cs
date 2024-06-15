using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rolestartt : MonoBehaviour
{
    private Animator m_Animator = null;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rolestart()
    {
        Debug.Log(m_Animator);
        m_Animator.SetBool("ispushed", true);
    }
}
