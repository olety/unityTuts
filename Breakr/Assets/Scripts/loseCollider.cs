using UnityEngine;
using System.Collections;

public class loseCollider : MonoBehaviour {

	public string loseScene;
	private levelController controller;

	// Find our levelController in the scene
	void Start () {
		controller = GameObject.FindObjectOfType<levelController> ();
	}

	// When ball hits the lose collider, load the loseScene
	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log ("Trigger Lose Collider");
		controller.loadScene (loseScene);
	}
}
