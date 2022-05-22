using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    float damage, attackSpeed, criticaFactor, attackRange,health,healthRegen,armor,criticalChance;
    int coin;
    
    void Start()
    {

        if (PlayerPrefs.GetInt("GameSetBefore") == 1)
        {
            damage = PlayerPrefs.GetFloat("damage");
            attackSpeed = PlayerPrefs.GetFloat("attackSpeed");
            criticaFactor = PlayerPrefs.GetFloat("criticaFactor");
            attackRange = PlayerPrefs.GetFloat("attackRange");
            health = PlayerPrefs.GetInt("health");
            healthRegen = PlayerPrefs.GetFloat("healthRegen");
            armor = PlayerPrefs.GetFloat("armor");
            criticalChance = PlayerPrefs.GetFloat("criticalChance");
            coin = PlayerPrefs.GetInt("coin");

            Debug.Log("GameSetBefore True");

            Debug.Log("Damage :" + damage);
            Debug.Log("attackSpeed" + attackSpeed);
            Debug.Log("criticalFactor" + criticaFactor);
            Debug.Log("attackRange" + attackRange);
            Debug.Log("health" + health);
            Debug.Log("healthRegen" + healthRegen);
            Debug.Log("armor" + armor);
            Debug.Log("criticalChance" + criticalChance);
            Debug.Log("coin" + coin);
            


        }
        else
        {
            Debug.Log("GameSetBefore False");

            PlayerPrefs.SetInt("GameSetBefore", 1);
            PlayerPrefs.SetFloat("damage", 5);
            PlayerPrefs.SetFloat("attackSpeed", 1);
            PlayerPrefs.SetFloat("criticaFactor", 1);
            PlayerPrefs.SetFloat("armor", 0);
            PlayerPrefs.SetInt("health", 5);
            PlayerPrefs.SetFloat("attackRange", 10);
            PlayerPrefs.SetFloat("healthRegen", 0);
            PlayerPrefs.SetFloat("criticalChance", 0);
            PlayerPrefs.SetInt("coin", 50);

        }
    }

    
}
