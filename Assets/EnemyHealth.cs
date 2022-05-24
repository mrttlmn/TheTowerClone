using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 10;
    public ParticleSystem destroyEffect;
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

    public void TakeDamage(float Damage)
    {
        Health -= Damage;

        storeManager.GetComponent<StoreManager>().money += MoneyOnDestroy;
    }

    private void OnDestroy()
    {
        ParticleSystem particle = Instantiate(destroyEffect, this.gameObject.transform);
        particle.transform.parent = GameObject.Find("ParticleHolder").transform;
        particle.Play();

    }


}
