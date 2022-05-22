using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public float attackSpeed;
    public float attackPower;
    public float criticalChance;
    public float criticalFactor;
    public float attackRange;
    public GameObject storeManager;

    public GameObject bulletPrefab;

    public GameObject target;



    public float nextTimeToAttack = 0f;
    void Start()
    {
        storeManager = GameObject.Find("StoreManager");
        var ValuesHolder = storeManager.GetComponent<StoreManager>();
        attackSpeed = ValuesHolder.attackSpeed;
        attackPower = ValuesHolder.damage;
        criticalChance = ValuesHolder.criticalChance;
        criticalFactor = ValuesHolder.criticaFactor;
        attackRange = ValuesHolder.attackRange;

    }

    // Update is called once per frame
    void Update()
    {

        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(this.transform.position, 2);
        foreach (Collider2D collider in colliderArray)
        {
            if (collider.gameObject.GetComponent<EnemyAI>() != null)
            {
                target = collider.gameObject;
            }

        }

        if (target.GetComponent<EnemyAI>() != null)
        {
            nextTimeToAttack -= Time.deltaTime;
            if(nextTimeToAttack < 0f)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                bullet.GetComponent<BulletScript>().damage = Convert.ToInt32(attackPower);
                rb.AddForce(target.transform.position * attackSpeed, ForceMode2D.Impulse);

                nextTimeToAttack = attackSpeed;
                Debug.Log("Attacking");
            }
               

        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, 1);
    }
}
