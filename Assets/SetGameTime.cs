using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameTime : MonoBehaviour
{
    public float time = 1;
    public Text tmtext;
    public void TimeMinus()
    {
        if(time > 0.50f)
        {
            time -= 0.25f;
        }
    }
    public void TimePlus()
    {
        if (time < 2f)
        {
            time += 0.25f;
        }
    }
    public void Update()
    {
        Time.timeScale = time;
        tmtext.text = time.ToString();
    }
}
