using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour {

	public GameObject car;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CarSpawn", 3f, 8f);
	}

	void CarSpawn() {
		Vector2 spawnPos = new Vector2(9.5f, -3f);
		Instantiate(car, spawnPos, Quaternion.identity);
	}
}
