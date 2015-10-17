using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lifeCount : MonoBehaviour {
	public int life;
	private Text text;
	// Use this for initialization
	void Start () {
		text = this.transform.GetComponent<Text> ();
		text.text = life.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
