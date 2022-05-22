using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 10;

    public int MoneyOnDestroy = 1;
    public GameObject storeManager;

    public void Start()
    {
        storeManager = GameObject.Find("StoreManager");
    }
    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;

        storeManager.GetComponent<StoreManager>().money += MoneyOnDestroy;
    }
}
