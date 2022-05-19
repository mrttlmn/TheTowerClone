using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public int WaveId;
    public List<WaveData> WaveDataset;
    public float NextWaveInSeconds;
    public float SpawnRate;
}
[System.Serializable]
public class WaveData
{
    public GameObject Enemy;
    public int Count;
}
