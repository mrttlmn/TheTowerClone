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

    float targetDistance;

    bool targetLocked;

    public float nextTimeToAttack = 0f;
    public AudioSource ShootSFX;
    public Transform range;
    // Update is called once per frame
    void Update()
    {

        
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(this.transform.position, attackRange * 0.2f);
        if (target != null)
        {
            targetDistance = Vector2.Distance(this.gameObject.transform.position, target.transform.position);
        }

        foreach (Collider2D collider in colliderArray)
        {
            var distance = Vector2.Distance(this.gameObject.transform.position, collider.transform.position);
            if (collider.gameObject.GetComponent<EnemyAI>() != null)
            {
                if (distance < targetDistance || target == null)
                {
                    target = collider.gameObject;
                }
            }

        }




        if (target != null)
        {

            nextTimeToAttack -= Time.deltaTime;
            if (nextTimeToAttack < 0f)
            {

                Shoot(target.transform.position);
                nextTimeToAttack = attackSpeed;
            }

        }
        Debug.Log(attackRange);

        range.localScale = new Vector3(attackRange * 0.2f, attackRange * 0.2f, 0);

    }

    void Shoot(Vector2 enemyPosition)
    {
        ShootSFX.Play();
        GameObject bullet = Instantiate(bulletPrefab, this.gameObject.transform.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().target = enemyPosition;
        bullet.GetComponent<BulletScript>().damage = attackPower;
    }
}
