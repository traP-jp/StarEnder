using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource seSource1;
    public AudioSource seSource2;

    public AudioClip bgmClip;
    public AudioClip seClip1;
    public AudioClip seClip2;

    void Start()
    {
        // BGMの再生を開始
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (bgmSource != null && bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }
    public void PlaySE1()
    {
        if (seSource1 != null && seClip1 != null)
        {
            seSource1.PlayOneShot(seClip1);
        }
    }
    public void PlaySE2()
    {
        if (seSource2 != null && seClip2 != null)
        {
            seSource2.PlayOneShot(seClip2);
            Debug.Log("ボタンがクリックされました！");
        }
    }
}