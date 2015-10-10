using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelController : MonoBehaviour {
	// Autoplay makes our paddle move by itself
	public static bool autoPlay = false;
	public Text autoPlayButton;

	// Load level with name sceneName
	public void loadScene ( string sceneName ) {
		Block.countBreakable = 0;
		Debug.Log ("Scene load requested for: " + sceneName);
		Application.LoadLevel (sceneName);
	}

	public void quitGame () {
		Debug.Log ("Game quit requested");
		Application.Quit();
	}

	// Load next level on the buildSettings
	public void loadNextLevel () {
		Block.countBreakable = 0;
		Application.LoadLevel (Application.loadedLevel+1);
	}

	// If block is destroyed, we need to check if we've won
	public void blockDestroyed () {
		if ( Block.countBreakable <= 0 ){
			loadNextLevel();
		}
	}

	// If user switcher the mode of autoplay, adjust the button accordingly
	public void autoModeSwitch () {
		autoPlay = !autoPlay;
		autoPlayButton.text = "Auto mode : " + (autoPlay ? "on" : "off");
	}

}