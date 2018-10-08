using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {

    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 movePosition;

	void Start () {
        startPosition = new Vector2(-9.5f, -2.95f);
        endPosition = new Vector2(9.5f, -2.95f);

        movePosition = startPosition; //start at beginning
        this.transform.position = movePosition;
	}
	
	void FixedUpdate () {
		if (transform.position.x < endPosition.x) {
            movePosition.x += .03f;
            this.transform.position = movePosition;
        } else {
            Destroy(this.gameObject);
        }
	}
}
