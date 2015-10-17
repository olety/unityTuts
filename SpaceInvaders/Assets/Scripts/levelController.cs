using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelController : MonoBehaviour {
	public bool gameStarted = false;
	public bool enemiesRespawning = false;
	// Load level with name sceneName
	public void loadScene ( string sceneName ) {
		Debug.Log ("Scene load requested for: " + sceneName);
		Application.LoadLevel (sceneName);
	}

	public void quitGame () {
		Debug.Log ("Game quit requested");
		Application.Quit();
	}
}