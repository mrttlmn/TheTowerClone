using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float damage;
    
    public float time = 3f;
    public Vector2 target;
    public int bulletSpeed = 5;

    Vector3 road;
    private void Start()
    {
        Vector2.MoveTowards(this.transform.position, target, 2);
        var locationX = this.transform.position.x;
        var locationY = this.transform.position.y;
        road = target - new Vector2(locationX, locationY);

    }
    public void Update()
    {
        transform.position += new Vector3(road.x,road.y,0) * Time.deltaTime * bulletSpeed;
    }
    private void Awake()
    {
        Destroy(this.gameObject, time);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(Convert.ToInt32(damage));
            Destroy(this.gameObject);
        }
    }
}
