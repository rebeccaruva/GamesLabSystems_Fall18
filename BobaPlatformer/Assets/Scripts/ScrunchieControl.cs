using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrunchieControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public int direction = 1;
    public int speed = 400;

    private bool canDestroy = false;

    GameObject player;

    IEnumerator Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * direction * speed);

        player = GameObject.FindGameObjectWithTag("Player");

        Destroy(this.gameObject, 5f);

        yield return new WaitForSeconds(.2f);
        canDestroy = true;
    }

    void FixedUpdate()
    {
        rb.AddForce((player.transform.position-transform.position) * 10);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            if (canDestroy) {
                Destroy(this.gameObject);
            }
        }
    }
}