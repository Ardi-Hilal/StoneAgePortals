using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] AudioSource bgm;

    public void OnBGM()
    {
        bgm.Play();
    }

    public void OffBGM()
    {
        bgm.Stop();
    }

}
