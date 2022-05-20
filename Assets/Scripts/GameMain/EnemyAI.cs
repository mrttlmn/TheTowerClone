using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    public GameObject Target;

    public float nextTimeToAttack;
    public float attackRate;
    public int damagePower;
    void Start()
    {
       Target = GameObject.Find("Tower");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,Target.transform.position, speed * Time.deltaTime);
        transform.up = Target.transform.position - transform.position;
        
    }
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tower")
        {
            nextTimeToAttack -= Time.deltaTime;
            if(nextTimeToAttack <= 0)
            {
                GameObject.Find("Tower").GetComponent<TowerHealth>().TakeDamage(damagePower);
                nextTimeToAttack = attackRate * 0.1f;

            }
        }
    }
}
