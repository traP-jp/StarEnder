using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zikkouyou : MonoBehaviour
{
    AttackScript attackscript;
    // Start is called before the first frame update
    void Start()
    {
        attackscript = GetComponent<AttackScript>();

        attackscript.Attackanim();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
