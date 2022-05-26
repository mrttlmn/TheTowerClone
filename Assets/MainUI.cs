using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public Canvas Upgrade, Battle, Settings;


    public void OpenUpgrade()
    {
        
        Upgrade.gameObject.SetActive(true);
        Battle.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);
    }
    public void OpenSettings()
    {    
        Settings.gameObject.SetActive(true);
        Battle.gameObject.SetActive(false);
        Upgrade.gameObject.SetActive(false);
    } 
    public void OpenBattle()
    {    
        Battle.gameObject.SetActive(true);
        Upgrade.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);

    }
    
       
    
}
