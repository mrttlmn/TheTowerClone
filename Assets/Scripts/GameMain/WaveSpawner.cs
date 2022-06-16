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


    // infinity wave
    public GameObject Enemy5;
    public GameObject Enemy50;
    public GameObject Enemy500;
    public GameObject Enemy5000;
    public GameObject Enemy50000;
    public GameObject Enemy500000;


    public int wavePoint;
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
    private void SpawnEnemy(GameObject enemy)
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
        var Enemy = GameObject.Instantiate(enemy, position: spawnPoint, Quaternion.identity);
        Enemy.transform.parent = GameObject.Find("EnemyHolder").transform;


        var EnemyAttackStats = Enemy.GetComponent<EnemyAI>();
        EnemyAttackStats.damagePower += damageMultiplier;
        var EnemyHealthStats = Enemy.GetComponent<EnemyHealth>();
        EnemyHealthStats.Health += healthMultiplier;
    }
    IEnumerator WaveStart(Slider slider)
    {
        wavePoint = 25;

        while (true)
        {
            Debug.Log("started");
            int i = wavePoint;

            while (i > 0)
            {
               while(i - 500000 >= 0)
                {
                    SpawnEnemy(Enemy500000);
                    i -= 500000;
                    Debug.Log("Spawn 500000");
                }
                while (i - 50000 >= 0)
                {
                    SpawnEnemy(Enemy50000);
                    i -= 50000;
                    Debug.Log("Spawn 50000");

                }
                while (i - 5000 >= 0)
                {
                    SpawnEnemy(Enemy5000);
                    i -= 5000;
                    Debug.Log("Spawn 5000");

                }

                while (i - 500 >= 0)
                {
                    SpawnEnemy(Enemy500);
                    i -= 500;
                    Debug.Log("Spawn 500");

                }

                while (i - 50 >= 0)
                {
                    SpawnEnemy(Enemy50);
                    i -= 50;
                    Debug.Log("Spawn 50");

                }
                while (i - 5 >= 0)
                {
                    SpawnEnemy(Enemy5);
                    i -= 5;
                    Debug.Log("Spawn 5");

                }
            }
            slider.minValue = 0;
            slider.maxValue = 10;
            slider.value = slider.maxValue;
            wavePoint += 50;
            yield return new WaitForSeconds(10);
        }
        //foreach (Wave wave in Waves)
        //{
        //    Debug.Log(wave.NextWaveInSeconds);
        //    slider.minValue = 0;
        //    slider.maxValue = wave.NextWaveInSeconds;
        //    slider.value = slider.maxValue;

        //    Debug.Log(wave.name + " Started");
        //    foreach (WaveData waveData in wave.WaveDataset)
        //    {

        //        for (int i = 0; i <= waveData.Count; i++)
        //        {

        //            var randX = Random.Range(-MaxSpawnDistance, MaxSpawnDistance);
        //            var randY = Random.Range(-MaxSpawnDistance, MaxSpawnDistance);
        //            var spawnPoint = new Vector2(randX, randY);
        //            var ds = Vector2.Distance(new Vector2(randX, randY), Tower.transform.position);
        //            if (ds <= MinSpawnDistance)
        //            {
        //                spawnPoint.x += MinSpawnDistance;
        //                spawnPoint.y += MinSpawnDistance;
        //            }
        //            var Enemy = GameObject.Instantiate(waveData.Enemy, position: spawnPoint, Quaternion.identity);
        //            Enemy.transform.parent = GameObject.Find("EnemyHolder").transform;


        //            var EnemyAttackStats = Enemy.GetComponent<EnemyAI>();
        //            EnemyAttackStats.damagePower += damageMultiplier;
        //            var EnemyHealthStats = Enemy.GetComponent<EnemyHealth>();
        //            EnemyHealthStats.Health += healthMultiplier;
        //        }
        //        healthMultiplier += 5f;
        //        damageMultiplier += 0.25f;
        //        yield return new WaitForSeconds(wave.NextWaveInSeconds);
        //    }
        //}
        StopCoroutine(WaveStart(slider));
    }
}
