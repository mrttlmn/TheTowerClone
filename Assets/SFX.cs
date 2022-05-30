using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    public static bool SoundStatus;

  
    void Start()
    {
        this.GetComponent<Toggle>().isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Toggle>().isOn)
        {
            SoundStatus = true;
        }
        else
        {
            SoundStatus = false;
        }
    }
}
