using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] Waves;

    void Start()
    {
        
    }
    void Update()
    {
        foreach (Wave wave in Waves)
        {
            foreach(WaveData waveData in wave.WaveDataset)
            {
                for(int i = 0;i >= waveData.Count; i++)
                {
                    
                }
            }
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 30);;
    }
    
}
