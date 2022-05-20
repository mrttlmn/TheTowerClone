using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int Health;
    void Start()
    {
        int BaseHealth = PlayerPrefs.GetInt("health");
        PlayerPrefs.SetInt("healthTmp", BaseHealth);
        Health = BaseHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            Debug.LogWarning("DED");
        }
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        PlayerPrefs.SetInt("healthTmp", Health);
    }
}
