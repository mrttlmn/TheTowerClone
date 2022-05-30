using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXController : MonoBehaviour
{
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;

    
    public void Start()
    {
        Debug.LogWarning(SFX.SoundStatus);
        if (SFX.SoundStatus)
        {
            sound1.mute = false;
            sound2.mute = false;
            sound3.mute = false;
        }
        else
        {
            sound1.mute=true;
            sound2.mute=true;   
            sound3.mute=true;
        }
    }
}
