using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    private bool btnF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (btnF!)
        {
            btnF = true;
            Toujou();
        }
    }

    public void Toujou()
    {
        transform.DOLocalMove(new Vector3(10f, 0, 0), 1f);
    }
}
