using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator m_Animator = null;
    private bool btnF;
    public GameObject dark;
    // Start is called before the first frame update
    void Start()
    {
        dark.gameObject.SetActive(false);
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (btnF == false)
        {
            btnF = true;
            Toujou();
            dark.gameObject.SetActive(true);
            
        }else{
            btnF = false;
            Taijou();
            dark.gameObject.SetActive(false);
        }

    }

    public void Toujou()
    {
        //transform.DOLocalMove(new Vector3(-225f, -561f, 0), 1f);
        m_Animator.SetBool("flag", true);
    }
    public void Taijou()
    {
        //transform.DOLocalMove(new Vector3(-225f, 0, 0), 1f);
        m_Animator.SetBool("flag", false);
    }
}
