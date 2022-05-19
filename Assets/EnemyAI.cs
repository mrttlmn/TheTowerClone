using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    public GameObject Target;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,Target.transform.position, speed * Time.deltaTime);
        transform.up = Target.transform.position - transform.position;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colide");
    }
}
