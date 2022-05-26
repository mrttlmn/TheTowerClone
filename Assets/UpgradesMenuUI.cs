using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenuUI : MonoBehaviour
{
    public int Coin;
    public float DamageVal, HealthVal, AttackSpeedVal, HealthRegenVal, CriticalFactorVal, CriticalChangeVal, ArmorVal, AttackRangeVal;
    public int DamageP, HealthP, AttackSpeedP, HealthRegenP, CriticalFactorP, CriticalChangeP, ArmorP, AttackRangeP;

    public Text DamageValue, HealthValue, AttackRangeValue, HealthRegenValue, CriticalChangeValue, ArmorValue, CriticalFactorValue, AttackSpeedValue;
    public Text CoinText,DamagePrice, HealthPrice, AttackRangePrice, HealthRegenPrice, CriticalChangePrice, ArmorPrice, CriticalFactorPrice, AttackSpeedPrice;

    void Start()
    {
        DamageVal = PlayerPrefs.GetFloat("damage");
        AttackSpeedVal = PlayerPrefs.GetFloat("attackSpeed");
        CriticalFactorVal = PlayerPrefs.GetFloat("criticaFactor");
        AttackRangeVal = PlayerPrefs.GetFloat("attackRange");
        HealthVal = PlayerPrefs.GetInt("health");
        HealthRegenVal = PlayerPrefs.GetFloat("healthRegen");
        ArmorVal = PlayerPrefs.GetFloat("armor");
        CriticalChangeVal = PlayerPrefs.GetFloat("criticalChance");
        Coin = PlayerPrefs.GetInt("coin");

        

        DamageP = PlayerPrefs.GetInt("damageP");
        AttackSpeedP = PlayerPrefs.GetInt("attackSpeedP");
        AttackRangeP = PlayerPrefs.GetInt("attackRangeP");
        HealthP = PlayerPrefs.GetInt("healthP");
        ArmorP = PlayerPrefs.GetInt("armorP");
        CriticalChangeP = PlayerPrefs.GetInt("criticalChangeP");
        CriticalFactorP = PlayerPrefs.GetInt("criticalFactorP");
        HealthRegenP = PlayerPrefs.GetInt("healthRegenP");
    }

    // Update is called once per frame
    void Update()
    {
        DamageValue.text = DamageVal.ToString();
        HealthValue.text = HealthVal.ToString();
        AttackRangeValue.text = AttackRangeVal.ToString();
        HealthRegenValue.text = HealthRegenVal.ToString();
        CriticalChangeValue.text = CriticalChangeVal.ToString();
        CriticalFactorValue.text = CriticalFactorVal.ToString();
        ArmorValue.text = ArmorVal.ToString();
        AttackSpeedValue.text = AttackSpeedVal.ToString();

        DamagePrice.text = DamageP.ToString();
        HealthRegenPrice.text = HealthRegenP.ToString();    
        HealthPrice.text = HealthP.ToString();
        AttackRangePrice.text = AttackRangeP.ToString();
        CriticalFactorPrice.text = CriticalFactorP.ToString();
        CriticalChangePrice.text = CriticalChangeP.ToString();
        ArmorPrice.text = ArmorP.ToString();
        AttackSpeedPrice.text = AttackSpeedP.ToString();
        CoinText.text = Coin.ToString(); 
    }
    public void UpgradeDamage()
    {
        if(Coin >= DamageP)
        {
            Coin -= DamageP;
            DamageVal += 5;
            DamageP += 5;
            PlayerPrefs.SetFloat("damage", DamageVal);
            PlayerPrefs.SetInt("damageP", Convert.ToInt32(DamageP));
            PlayerPrefs.SetInt("coin", Coin);
        }
    }
    public void UpgradeAttackSpeed()
    {
        if (Coin >= AttackSpeedP)
        {
            Coin -= AttackSpeedP;
            AttackSpeedVal -= 0.05f;
            AttackSpeedP += 5;
            PlayerPrefs.SetFloat("attackSpeed", AttackSpeedVal);
            PlayerPrefs.SetInt("attackSpeedP", Convert.ToInt32(AttackSpeedP));
            PlayerPrefs.SetInt("coin", Coin);

        }
    }
    public void UpgradeAttackRange()
    {
        if (Coin >= AttackRangeP)
        {
            Coin -= AttackRangeP;
            AttackRangeVal += 1;
            AttackRangeP += 5;
            PlayerPrefs.SetFloat("attackRange",AttackRangeVal);
            PlayerPrefs.SetInt("attackRangeP", Convert.ToInt32(AttackRangeP));
            PlayerPrefs.SetInt("coin", Coin);

        }
    }
    public void UpgradeHealthRegen()
    {
        if (Coin >= HealthRegenP)
        {
            Coin -= HealthRegenP;
            HealthRegenVal += 0.2f;
            HealthRegenP += 5;
            PlayerPrefs.SetFloat("healthRegen", HealthRegenVal);
            PlayerPrefs.SetInt("healthRegenP", Convert.ToInt32(HealthRegenP));
            PlayerPrefs.SetInt("coin", Coin);

        }
    }
    public void UpgradeCriticalChance()
    {
        if (Coin >= CriticalChangeP)
        {
            Coin -= CriticalChangeP;
            CriticalChangeVal += 1;
            CriticalChangeP += 5;
            PlayerPrefs.SetFloat("criticalChance", CriticalChangeVal);
            PlayerPrefs.SetInt("criticalChanceP", Convert.ToInt32(CriticalChangeP));
            PlayerPrefs.SetInt("coin", Coin);

        }
    }
    public void UpgradeCriticalFactor()
    {
        if (Coin >= CriticalFactorP)
        {
            Coin -= CriticalFactorP;
            CriticalFactorVal += 0.10f;
            CriticalFactorP += 5;
            PlayerPrefs.SetFloat("criticalFactor", CriticalFactorVal);
            PlayerPrefs.SetInt("criticalFactorP", Convert.ToInt32(CriticalFactorP));
            PlayerPrefs.SetInt("coin", Coin);

        }
    }
    public void UpgradeArmor()
    {
        if (Coin >= ArmorP)
        {
            Coin -= ArmorP;
            ArmorVal += 5f;
            ArmorP += 5;
            PlayerPrefs.SetFloat("armor",ArmorVal);
            PlayerPrefs.SetInt("armorP", Convert.ToInt32(ArmorP));
            PlayerPrefs.SetInt("coin", Coin);

        }
    }
    public void UpgradeHealth()
    {
        if (Coin >= HealthP)
        {
            Coin -= HealthP;
            HealthVal += 5f;
            HealthP += 5;
            PlayerPrefs.SetFloat("armor", HealthVal);
            PlayerPrefs.SetInt("armorP", Convert.ToInt32(HealthP));
            PlayerPrefs.SetInt("coin", Coin);

        }
    }

}
