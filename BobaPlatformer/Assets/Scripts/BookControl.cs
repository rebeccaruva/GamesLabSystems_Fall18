using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public int direction = 1;
    public int speed = 400;

    private bool canDestroy = false;

    GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        Destroy(this.gameObject, 2f);

    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * 10);
    }

    void OnTriggerEnter2D(Collider2D coll)
	{
			
    }
}