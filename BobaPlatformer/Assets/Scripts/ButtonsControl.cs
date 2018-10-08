using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsControl : MonoBehaviour {

	private Scene currentScene;

	void Start() {
		currentScene = SceneManager.GetActiveScene();
	}

	//play button
    public void PlayOnPress()
    {
        SceneManager.LoadScene("Lvl1");
    }

	//escape button
	public void LeaveOnPress() {
        Application.Quit();
    }

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("Player")) {
			if (currentScene.name == "Lvl1") {
				SceneManager.LoadScene("Lvl2");
			}
			
			if (currentScene.name == "Lvl2") {
				SceneManager.LoadScene("Lvl3");
			}
		}
	}
}
