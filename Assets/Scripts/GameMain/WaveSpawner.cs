using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] Waves;
    public float MaxSpawnDistance = 2, MinSpawnDistance = 1;
    public GameObject Tower;

    void Start()
    {
        Tower = GameObject.Find("Tower");
        StartCoroutine(WaveStart());
        
    }

    IEnumerator WaveStart()
    {
        foreach (Wave wave in Waves)
        {

            Debug.Log(wave.name + " Started");
            foreach (WaveData waveData in wave.WaveDataset)
            {

                for (int i = 0; i <= waveData.Count; i++)
                {

                    var randX = Random.Range(-MaxSpawnDistance, MaxSpawnDistance);
                    var randY = Random.Range(-MaxSpawnDistance, MaxSpawnDistance);
                    var spawnPoint = new Vector2(randX, randY);
                    var ds = Vector2.Distance(new Vector2(randX, randY), Tower.transform.position);
                    if (ds <= MinSpawnDistance)
                    {
                        spawnPoint.x += MinSpawnDistance;
                        spawnPoint.y += MinSpawnDistance;
                    }
                    GameObject.Instantiate(waveData.Enemy, position: spawnPoint, Quaternion.identity);
                }
                yield return new WaitForSeconds(wave.NextWaveInSeconds);
            }
        }
        StopCoroutine(WaveStart());
    }
}
