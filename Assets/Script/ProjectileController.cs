using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private int speed = 3;

   
    
    void Start()
    { GetComponent<Rigidbody2D>().velocity = transform.up * speed; }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnEnable() {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("bullets");

        foreach (GameObject obj in otherObjects) {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        transform.up = Vector2.Reflect(transform.up, collision.contacts[0].normal);
            GetComponent<Rigidbody2D>().velocity = transform.up * speed;
            speed += 1;

        }
    }

