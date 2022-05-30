using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCircle : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;

    void Start()
    {
        lr = this.gameObject.GetComponent<LineRenderer>();


        DrawCircle(100, 1);
    }

   
    void DrawCircle(int step , float radius)
    {
        lr.positionCount = step;
        for(int currentStep = 0; currentStep < step; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / step;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x,y,0);   

            lr.SetPosition(currentStep, currentPosition);
        }

    }
}
