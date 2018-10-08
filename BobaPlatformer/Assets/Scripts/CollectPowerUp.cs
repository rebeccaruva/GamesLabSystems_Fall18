using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPowerUp : MonoBehaviour {

	private PlayerMove bookBool;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		bookBool = player.GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void onTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.CompareTag("Player")) {
			bookBool.bookPower = true;
			Debug.Log(bookBool.bookPower);
			Destroy(this.gameObject);
		}
	}
}
