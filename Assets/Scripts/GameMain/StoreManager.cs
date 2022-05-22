using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{

    public float attackSpeed, criticaFactor, attackRange, healthRegen, criticalChance,damage, armor;
    public float damageCurrentPrice = 10, attackSpeedCurrentPrice = 10, criticaFactorCurrentPrice = 10, attackRangeCurrentPrice = 10, healthCurrentPrice = 10, healthRegenCurrentPrice = 10, armorCurrentPrice = 10, criticalChanceCurrentPrice = 10;
    public int coin,health;
    int money = 1000;
    public Text CoinText;
    public Text MoneyText;
     
    public Text AttackRangeBtnPrice,ArmorBtnPrice, HealthRegenBtnPrice, HealthBtnPrice, AttackRangeBtnValue, ArmorBtnValue, HealthRegenBtnValue, HealthBtnValue, DamageBtnValue, DamageBtnPrice, AttackSpeedBtnValue, AttackSpeedBtnPrice, CriticalFactorBtnValue, CriticalFactorBtnPrice,CriticalChangeBtnValue,CriticalChangeBtnPrice;

    #region GameStoreSettings
    private readonly float PriceMultiplier = 1.2f;
    private readonly float DamageMultiplier = 1.4f;
    private readonly float AttackSpeedMultiplier = 1.05f;
    private readonly float CriticaFactorMultiplier = 1.05f;
    private readonly float CriticalChanceMultiplier = 1.3f;
    private readonly float HealthRegenMultiplier = 1.3f;
    private readonly float ArmorMultiplier = 1.3f;

    #endregion

    public GameObject Tower;

    void Start()
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


        PlayerPrefs.SetFloat("damageTmp", damage);
        PlayerPrefs.SetFloat("attackSpeedTmp", attackSpeed);
        PlayerPrefs.SetFloat("criticalFactorTmp", criticaFactor);
        PlayerPrefs.SetInt("healthTmp", health);
        PlayerPrefs.SetFloat("healthRegenTmp", healthRegen);
        PlayerPrefs.SetFloat("attackRangeTmp", attackRange);
        PlayerPrefs.SetFloat("armorTmp", armor);
        PlayerPrefs.SetFloat("criticalChanceTmp", criticalChance);
        PlayerPrefs.SetInt("coinTmp", coin);
        PlayerPrefs.SetInt("moneyTmp", money);


        
        
        RestoreValues();
        
    }

  

    public void UpgradeDamage()
    {
        if(money >= damageCurrentPrice)
        {
            money = money - (int)damageCurrentPrice;
            damage = damage * DamageMultiplier;
            damageCurrentPrice = damageCurrentPrice * PriceMultiplier;
            
            PlayerPrefs.SetInt("moneyTmp", money);
            PlayerPrefs.SetFloat("damageTmp", damage);
            RestoreValues();

        }
    }
    public void UpgradeAttackSpeed()
    {
        if (money >= attackSpeedCurrentPrice)
        {
            money = money - (int)attackSpeedCurrentPrice;
            attackSpeed = attackSpeed * AttackSpeedMultiplier;
            attackSpeedCurrentPrice = attackSpeedCurrentPrice * PriceMultiplier;
            PlayerPrefs.SetInt("moneyTmp", money);
            PlayerPrefs.SetFloat("attackSpeedTmp", attackSpeed);
            RestoreValues();

        }
    }
    public void UpgradeCriticalFactor()
    {
        if (money >= criticaFactorCurrentPrice)
        {

            money = money - (int)criticaFactorCurrentPrice;
            criticaFactor = criticaFactor * CriticaFactorMultiplier;
            criticaFactorCurrentPrice = criticaFactorCurrentPrice * PriceMultiplier;

            PlayerPrefs.SetInt("moneyTmp", money);
            PlayerPrefs.SetFloat("criticalFactorTmp", criticaFactor);
            RestoreValues();

        }
    }
    public void UpgradeCriticaChange()
    {
        if (money >= criticalChanceCurrentPrice)
        {
            money = money - (int)criticalChanceCurrentPrice;


            if (criticalChance == 0)
                criticalChance = 1;
            else
                criticalChance = criticalChance * CriticalChanceMultiplier;


            criticalChanceCurrentPrice = criticalChanceCurrentPrice * PriceMultiplier;

            PlayerPrefs.SetInt("moneyTmp", money);
            PlayerPrefs.SetFloat("criticalChangeTmp", criticaFactor);
            RestoreValues();

        }
    }
    public void UpgradeHealth()
    {
        if (money >= healthCurrentPrice)
        {
            money = money - (int)healthCurrentPrice;
            health += 5;
            healthCurrentPrice = healthCurrentPrice * PriceMultiplier;

            PlayerPrefs.SetInt("moneyTmp", money);
            PlayerPrefs.SetInt("healthTmp", health);
            RestoreValues();

        }
    }
    public void UpgradeHealthRegen()
    {
        if (money >= healthRegenCurrentPrice)
        {
            money = money - (int)healthRegenCurrentPrice;


            if (healthRegen == 0)
                healthRegen = 0.1f;
            else
                healthRegen = healthRegen * HealthRegenMultiplier;

            healthRegenCurrentPrice = healthRegenCurrentPrice * PriceMultiplier;
            PlayerPrefs.SetInt("moneyTmp", money);
            PlayerPrefs.SetFloat("healthRegenTmp", healthRegen);
            RestoreValues();

        }
    }
    public void UpgradeArmor()
    {
        if (money >= armorCurrentPrice)
        {
            money = money - (int)armorCurrentPrice;


            if (armor == 0)
                armor = 1;
            else
                armor = armor * ArmorMultiplier;

            armorCurrentPrice = armorCurrentPrice * PriceMultiplier;
            PlayerPrefs.SetInt("moneyTmp", money);
            PlayerPrefs.SetFloat("armorTmp", armor);
            RestoreValues();

        }
    }
    public void UpgradeAttackRange()
    {
        if (money >= armorCurrentPrice)
        {
            money = money - (int)attackRangeCurrentPrice;
            attackRange += 2;

            attackRangeCurrentPrice = attackRangeCurrentPrice * PriceMultiplier;
            PlayerPrefs.SetInt("moneyTmp", money);
            PlayerPrefs.SetFloat("attackRangeTmp", attackRange);
            RestoreValues();

        }
    }


    public void RestoreValues()
    {
        DamageBtnValue.text = PlayerPrefs.GetFloat("damageTmp").ToString();
        CriticalFactorBtnValue.text = PlayerPrefs.GetFloat("criticalFactorTmp").ToString();
        AttackSpeedBtnValue.text = PlayerPrefs.GetFloat("attackSpeedTmp").ToString();
        CriticalChangeBtnValue.text = PlayerPrefs.GetFloat("criticaChangeTmp").ToString();
        HealthBtnValue.text = PlayerPrefs.GetInt("healthTmp").ToString();
        HealthRegenBtnValue.text = PlayerPrefs.GetFloat("healthRegenTmp").ToString();
        ArmorBtnValue.text = PlayerPrefs.GetFloat("armorTmp").ToString();
        AttackRangeBtnValue.text = PlayerPrefs.GetInt("attackRangeTmp").ToString();

        DamageBtnPrice.text = damageCurrentPrice.ToString();
        CriticalFactorBtnPrice.text = criticaFactorCurrentPrice.ToString();
        AttackSpeedBtnPrice.text = attackSpeedCurrentPrice.ToString();
        CriticalChangeBtnPrice.text = criticalChanceCurrentPrice.ToString();
        HealthBtnPrice.text = healthCurrentPrice.ToString();
        HealthRegenBtnPrice.text = healthRegenCurrentPrice.ToString();
        ArmorBtnPrice.text = armorCurrentPrice.ToString();
        AttackRangeBtnPrice.text = attackRangeCurrentPrice.ToString();
        CoinText.text = coin.ToString();
        MoneyText.text = money.ToString();
    }
}
