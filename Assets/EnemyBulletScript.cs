using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float damage;

    public float time = 3f;
    public Vector2 target;
    public int bulletSpeed = 5;

    Vector3 road;
    private void Start()
    {
        Vector2.MoveTowards(this.gameObject.transform.position, target, 2);
        var locationX = this.transform.position.x;
        var locationY = this.transform.position.y;
        road = target - new Vector2(locationX, locationY);
        Physics.IgnoreLayerCollision(0,15);

    }
    public void Update()
    {
        this.gameObject.transform.position += new Vector3(road.x, road.y, 0) * Time.deltaTime * bulletSpeed;
    }
    private void Awake()
    {
        Destroy(this.gameObject, time);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerHealth>() != null)
        {
            Debug.LogWarning("iht");
            collision.gameObject.GetComponent<TowerHealth>().TakeDamage(Convert.ToInt32(damage));
            Destroy(this.gameObject);
        }
    }
}
