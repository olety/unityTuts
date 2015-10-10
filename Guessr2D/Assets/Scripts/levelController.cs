using UnityEngine;
using System.Collections;

public class levelController : MonoBehaviour {
	
	public void loadScene ( string sceneName ){
		Debug.Log ("Scene load requested for: " + sceneName);
		Application.LoadLevel (sceneName);
	}

	public void quitGame ( ){
		Debug.Log ("Game quit requested ");
		Application.Quit();
	}

}