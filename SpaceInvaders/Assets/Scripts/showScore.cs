using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Text>().text = scoreKeeper.getScore ().ToString();
	}

}
