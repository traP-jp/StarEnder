using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attackanim()
    {
        transform.DOLocalMove(new Vector3(0.7f, 0, 0), 0.1f).SetRelative(true);
        transform.DOLocalMove(new Vector3(-0.7f, 0, 0), 0.1f).SetRelative(true).SetDelay(0.2f);
        Debug.Log("atakkusaretayo");
    }
}
