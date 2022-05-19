using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject DefanceUpgradesSection;
    public GameObject AttackUpgradesSection;
    public GameObject UtilityUpgradesSection;
    public Text CoinText;
    public Text MoneyText;
    void Start()
    {
        DefanceUpgradesSection.SetActive(false);
        AttackUpgradesSection.SetActive(false);
        UtilityUpgradesSection.SetActive(false);
        
        
    }

    [System.Obsolete]
    public void OpenDefenceUpgradesMenu()
    {
        if(DefanceUpgradesSection.active == true)
        {
           DefanceUpgradesSection.SetActive(false);
        }
        else
        {
            DefanceUpgradesSection.SetActive(true);
        }
        
        AttackUpgradesSection.SetActive(false);
        UtilityUpgradesSection.SetActive(false);
    }

    [System.Obsolete]
    public void OpenAttackUpgradesMenu()
    {
        if (AttackUpgradesSection.active == true)
        {
            AttackUpgradesSection.SetActive(false);
        }
        else
        {
            AttackUpgradesSection.SetActive(true);
        }

        DefanceUpgradesSection.SetActive(false);
        UtilityUpgradesSection.SetActive(false);
    }

    [System.Obsolete]
    public void OpenUtilityUpgradesMenu()
    {
        if (UtilityUpgradesSection.active == true)
        {
            UtilityUpgradesSection.SetActive(false);
        }
        else
        {
            UtilityUpgradesSection.SetActive(true);
        }

        DefanceUpgradesSection.SetActive(false);
        AttackUpgradesSection.SetActive(false);
    }
}
