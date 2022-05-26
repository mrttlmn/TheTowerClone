using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] Waves;
    public float MaxSpawnDistance = 2, MinSpawnDistance = 1;
    public GameObject Tower;
    public GameObject TimerSection;
    float timeLeft;
    public Text DamageMultiplier;
    public Text HealthMultiplier;
    public Slider sliderV;


    public float damageMultiplier;
    public float healthMultiplier;
    void Start()
    {
        Tower = GameObject.Find("Tower");
        sliderV = TimerSection.GetComponent<Slider>();
        StartCoroutine(WaveStart(sliderV));
      
    }
    private void Update()
    {
        sliderV.value -= Time.deltaTime;
        DamageMultiplier.text = damageMultiplier.ToString();
        HealthMultiplier.text = healthMultiplier.ToString();
    }
    IEnumerator WaveStart(Slider slider)
    {

        foreach (Wave wave in Waves)
        {
            Debug.Log(wave.NextWaveInSeconds);
            slider.minValue = 0;
            slider.maxValue = wave.NextWaveInSeconds;
            slider.value = slider.maxValue;
            
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
                    var Enemy = GameObject.Instantiate(waveData.Enemy, position: spawnPoint, Quaternion.identity);
                    Enemy.transform.parent = GameObject.Find("EnemyHolder").transform;

                    
                    var EnemyAttackStats = Enemy.GetComponent<EnemyAI>();
                    EnemyAttackStats.damagePower += damageMultiplier;
                    var EnemyHealthStats = Enemy.GetComponent<EnemyHealth>();
                    EnemyHealthStats.Health += healthMultiplier;
                }
                healthMultiplier += 5f;
                damageMultiplier += 0.25f;
                yield return new WaitForSeconds(wave.NextWaveInSeconds);
            }
        }
        StopCoroutine(WaveStart(slider));
    }
}
