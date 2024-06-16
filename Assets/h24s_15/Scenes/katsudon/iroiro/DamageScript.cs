using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damageanim()
    {
        transform.DOPunchPosition(new Vector3(0.2f, 0, 0), 1f, 5, 1f);

        SpriteRenderer.color = new Color32(255, 100, 0,255);
        
        Invoke(nameof(Chancol),0.7f);
    }
    public void Chancol()
    {
        SpriteRenderer.color = new Color32(255, 255, 255,255);
    }
}
