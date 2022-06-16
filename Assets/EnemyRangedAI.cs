using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAI : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    public GameObject Target;
    public GameObject bulletPrefab;

    public float nextTimeToAttack;
    public float attackRate;
    public float damagePower;
    public float attackRange;
    public string GUID;
    public bool inShootRange;
    void Start()
    {
        Target = GameObject.Find("Tower");
        GUID = Guid.NewGuid().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inShootRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
            transform.up = Target.transform.position - transform.position;
        }
        if(Vector2.Distance(transform.position, Target.transform.position) <= attackRange)
        {
            Vector2.MoveTowards(transform.position,transform.position, speed * Time.deltaTime);
            inShootRange = true;
        }
        if (inShootRange)
        {
            nextTimeToAttack -= Time.deltaTime;
            if (nextTimeToAttack <= 0)
            {
                Shoot(Target.transform.position);
                nextTimeToAttack = attackRate * 0.1f;
            }
        }

    }
    void Shoot(Vector2 enemyPosition) 
    { 
        GameObject bullet = Instantiate(bulletPrefab, this.gameObject.transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBulletScript>().target = enemyPosition;
        bullet.GetComponent<EnemyBulletScript>().damage = damagePower;
    }
   
}
