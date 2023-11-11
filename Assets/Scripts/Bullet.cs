using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private float speed = 5f;

    void Start()
    {
        Vector2 hareketYonu = Random.insideUnitCircle.normalized;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = hareketYonu * speed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Enemy")
        {
            Destroy(gameObject);
        }
    }
    
    
}
