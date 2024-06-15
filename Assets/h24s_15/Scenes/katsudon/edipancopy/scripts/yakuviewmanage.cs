using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class NewBehaviourScript : MonoBehaviour
{
    private bool btnF;
    public GameObject dark;
    // Start is called before the first frame update
    void Start()
    {
        dark.gameObject.SetActive(false);
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
        transform.DOLocalMove(new Vector3(0, 60f, 0), 1f);
    }
    public void Taijou()
    {
        transform.DOLocalMove(new Vector3(0, 350f, 0), 1f);
    }
}
