using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDiff : MonoBehaviour
{
    public Text text;
    public static int difficulty;

    public void Start()
    {
        difficulty = 1;
        text.text = "Level "+ difficulty.ToString();
    }
    public void LevelUp()
    {
        if (difficulty >= 3)
            difficulty = 1;
        else
            difficulty++;

        text.text = "Level " + difficulty.ToString();
    }
    public void LevelDown()
    {
        if (difficulty <= 1)
            difficulty = 3;
        else
            difficulty--;
        text.text = "Level " + difficulty.ToString();

    }
}
