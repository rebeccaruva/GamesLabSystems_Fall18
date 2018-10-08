using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMove : MonoBehaviour
{

    public float speed = .5f; //how fast it moves
    public float distance = 2f; //how far right it moves
    private float startPosition; //needs to get back to start

    public bool hit = false; //if kid is hit by attack
    public bool hitBack = false;

    private Transform player; //player transform
    private Rigidbody2D rb; //kid rigidbody 
    private SpriteRenderer sr; //kid sprite

    void Start()
    {
        startPosition = transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hit) {
            Vector2 newPosition = transform.position; //temp variable
            newPosition.x = Mathf.SmoothStep(startPosition, startPosition + distance, Mathf.PingPong(Time.time * speed, 1)); //assign
            transform.position = newPosition; //new calculated position
        } else {
            //if hit, then start following player
            float xDir = player.position.x - transform.position.x;
            Vector2 dir = new Vector2(xDir, 0f);
            dir.Normalize();
            rb.velocity = dir * speed;
        }

        if(transform.position.x > player.position.x) {
            sr.flipX = true;
        } else {
            sr.flipX = false;
        }

    }

    //if hit by scrunchie, die
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("tag: " + coll.gameObject.tag);
        if (coll.gameObject.CompareTag("scrunchie"))
        {
            hit = true;
        }
        if (coll.gameObject.CompareTag("Player"))
        {
            if (hitBack && hit) {
                //take off points from boba bar
                Debug.Log("peppa the pig hit you");
            }
        }
    }
}
