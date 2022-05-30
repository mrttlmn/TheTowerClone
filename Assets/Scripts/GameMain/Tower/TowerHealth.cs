using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{

    public float Health;
    public float HealthRegen;
    public float Armor;
    public int MaxHealth;


    Text healthBarText;
    Slider healthBar;


    float secondHandler = 0;
    
    void Start()
    {     
        healthBar = GameObject.Find("SectionLeft").GetComponent<Slider>();   
        healthBarText = GameObject.Find("HealthBarText").GetComponent<Text>();
    }

    void Update()
    {
        if(Health <= 0)
        {
            SceneManager.LoadScene("Menu");
        }      
        healthBar.maxValue = MaxHealth;
        healthBar.value = Health;

        // Verilerin UI Kýsmýnda Güncellenmesi
        healthBarText.text = Convert.ToInt32(Health) + " / " + MaxHealth.ToString();


        secondHandler -= Time.deltaTime;
        if(secondHandler < 0)
        {
            Health += HealthRegen;
            if(Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            secondHandler += 0.5f;
        }
    }

    public void TakeDamage(float Damage)
    {
        Health = Damage - Convert.ToInt32(Armor);
    }
}
