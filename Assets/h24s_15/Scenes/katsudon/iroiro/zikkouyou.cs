using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zikkouyou : MonoBehaviour
{
    AttackScript attackscript;
    DamageScript damagescript;
    // Start is called before the first frame update
    public void OnClick()
    {
        attackscript = GetComponent<AttackScript>();
        damagescript = GetComponent<DamageScript>();

        //attackscript.Attackanim();
        damagescript.Damageanim();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
