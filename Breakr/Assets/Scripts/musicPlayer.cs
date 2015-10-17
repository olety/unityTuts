using UnityEngine;
using System.Collections;

public class musicPlayer : MonoBehaviour {

	static musicPlayer instance = null;

	// Use this for initialization
	void Awake () {
//		If we haven't had a music player before, create a musicPlayer and assign the instance to it. otherwise, destroy this
		if (musicPlayer.instance != null) {
			Debug.Log ("Destroying duplicate musicPlayer");
			Destroy (gameObject);
		} else {
			musicPlayer.instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

}
