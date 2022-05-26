using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{

    public float attackSpeed, criticaFactor, attackRange, healthRegen, criticalChance, damage, armor;
    public float damageCurrentPrice = 10, attackSpeedCurrentPrice = 10, criticaFactorCurrentPrice = 10, attackRangeCurrentPrice = 10, healthCurrentPrice = 10, healthRegenCurrentPrice = 10, armorCurrentPrice = 10, criticalChanceCurrentPrice = 10;
    public int coin, health;
    public int money = 100;
    public Text CoinText;
    public Text MoneyText;
    public Text Damage,Health;
    public Text AttackRangeBtnPrice, ArmorBtnPrice, HealthRegenBtnPrice, HealthBtnPrice, AttackRangeBtnValue, ArmorBtnValue, HealthRegenBtnValue, HealthBtnValue, DamageBtnValue, DamageBtnPrice, AttackSpeedBtnValue, AttackSpeedBtnPrice, CriticalFactorBtnValue, CriticalFactorBtnPrice, CriticalChangeBtnValue, CriticalChangeBtnPrice;

    #region GameStoreSettings
    private readonly float PriceMultiplier = 1.2f;
    private readonly float DamageMultiplier = 1.4f;
    private readonly float CriticaFactorMultiplier = 1.05f;
    private readonly float CriticalChanceMultiplier = 1.3f;
    private readonly float HealthRegenMultiplier = 0.1f;
    private readonly float ArmorMultiplier = 1.3f;

    #endregion

    public GameObject Tower;
    public TowerAttack attackValues;
    public TowerHealth healthValues;

    void Start()
    {
        #region Kayýtlý Verilerin Getirilmesi
        damage = PlayerPrefs.GetFloat("damage");
        attackSpeed = PlayerPrefs.GetFloat("attackSpeed");
        criticaFactor = PlayerPrefs.GetFloat("criticaFactor");
        attackRange = PlayerPrefs.GetFloat("attackRange");
        health = PlayerPrefs.GetInt("health");
        healthRegen = PlayerPrefs.GetFloat("healthRegen");
        armor = PlayerPrefs.GetFloat("armor");
        criticalChance = PlayerPrefs.GetFloat("criticalChance");
        coin = PlayerPrefs.GetInt("coin");
        #endregion
        #region Verileri Ýlgili Scriptlere Ýletilmesi
        attackValues = Tower.GetComponent<TowerAttack>();
        healthValues = Tower.GetComponent<TowerHealth>();


        attackValues.attackPower = damage;
        attackValues.attackSpeed = attackSpeed;
        attackValues.attackRange = attackRange;
        attackValues.criticalChance = criticalChance;
        attackValues.criticalFactor = criticaFactor;

        healthValues.Armor = armor;
        healthValues.MaxHealth = health;
        healthValues.HealthRegen = healthRegen;
        healthValues.Health = health;


        #endregion

        #region Verilerin UI'a Gönderilmesi
        AttackRangeBtnValue.text = attackRange.ToString();
        AttackSpeedBtnValue.text = attackSpeed.ToString();
        DamageBtnValue.text = damage.ToString();
        CriticalChangeBtnValue.text = criticalChance.ToString();
        CriticalFactorBtnValue.text = criticaFactor.ToString();
        HealthBtnValue.text = health.ToString();
        ArmorBtnValue.text = armor.ToString();
        HealthRegenBtnValue.text = healthRegen.ToString();
        #endregion

    }
    private void Update()
    {
        MoneyText.text = money.ToString();
        CoinText.text = coin.ToString();
        Health.text = health.ToString();
        Damage.text = damage.ToString();
    }


    public void UpgradeDamage()
    {
        if (money >= damageCurrentPrice)
        {
            money = money - (int)damageCurrentPrice;
            damage = damage * DamageMultiplier;
            damageCurrentPrice = damageCurrentPrice * PriceMultiplier;
            DamageBtnPrice.text = damageCurrentPrice.ToString();
            DamageBtnValue.text = damage.ToString();
            attackValues.attackPower = damage;


        }
    }
    public void UpgradeAttackSpeed()
    {
        if (money >= attackSpeedCurrentPrice)
        {
            money = money - (int)attackSpeedCurrentPrice;
            attackSpeed = attackSpeed - 0.05f;
            attackSpeedCurrentPrice = attackSpeedCurrentPrice * PriceMultiplier;
            AttackSpeedBtnPrice.text = attackSpeedCurrentPrice.ToString();
            AttackSpeedBtnValue.text = (attackSpeed).ToString();
            attackValues.attackSpeed = attackSpeed;
        }
    }
    public void UpgradeCriticalFactor()
    {
        if (money >= criticaFactorCurrentPrice)
        {

            money = money - (int)criticaFactorCurrentPrice;
            criticaFactor = criticaFactor * CriticaFactorMultiplier;
            criticaFactorCurrentPrice = criticaFactorCurrentPrice * PriceMultiplier;
            CriticalFactorBtnPrice.text = criticaFactorCurrentPrice.ToString();
            CriticalFactorBtnValue.text = criticaFactor.ToString();

            attackValues.criticalFactor = criticaFactor;
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
            CriticalChangeBtnPrice.text = criticalChanceCurrentPrice.ToString();
            CriticalChangeBtnValue.text = criticalChance.ToString();
            attackValues.criticalChance = criticalChance;

        }
    }
    public void UpgradeHealth()
    {
        if (money >= healthCurrentPrice)
        {
            money = money - (int)healthCurrentPrice;
            health += 5;
            healthCurrentPrice = healthCurrentPrice * PriceMultiplier;

            HealthBtnPrice.text = healthCurrentPrice.ToString();
            HealthBtnValue.text = health.ToString();

            healthValues.MaxHealth = health;
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
                healthRegen += HealthRegenMultiplier;

            healthRegenCurrentPrice = healthRegenCurrentPrice * PriceMultiplier;
            HealthRegenBtnPrice.text = healthRegenCurrentPrice.ToString();
            HealthRegenBtnValue.text = healthRegen.ToString();

            healthValues.HealthRegen = healthRegen;

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
            ArmorBtnPrice.text = armorCurrentPrice.ToString();
            ArmorBtnValue.text = armor.ToString();

            healthValues.Armor = armor;
            //
        }
    }
    public void UpgradeAttackRange()
    {
        if (money >= armorCurrentPrice)
        {
            money = money - (int)attackRangeCurrentPrice;
            attackRange += 2;

            attackRangeCurrentPrice = attackRangeCurrentPrice * PriceMultiplier;
            AttackRangeBtnPrice.text = attackRangeCurrentPrice.ToString();
            AttackRangeBtnValue.text = attackRange.ToString();
            attackValues.attackRange = attackRange;
        }
    }

}
