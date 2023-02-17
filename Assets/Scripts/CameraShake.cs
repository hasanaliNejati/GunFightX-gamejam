using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;


    Animator anim;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }



    public static void NormalShake()
    {
        instance.anim.SetTrigger("NormalShake");
    }
    public static void HighShake()
    {
        instance.anim.SetTrigger("HighShake");
    }
}
