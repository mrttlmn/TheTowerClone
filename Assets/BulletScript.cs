using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public int damage;
    
    public float time = 3f;


    private void Awake()
    {
        Destroy(this.gameObject, time);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
