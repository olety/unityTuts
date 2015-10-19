using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreKeeper : MonoBehaviour {
	public Text scoreText;
	public Text healthText;
	public GameObject player;
	public float winScore;
	private static float savedScore;
	/// <summary>
	/// Adds the score.
	/// </summary>
	/// <param name="score">Score.</param>
	public void addScore ( float score ){
		setScore(float.Parse(scoreText.text) + score);
	}
	
	public void subScore ( float score ){
		setScore(float.Parse(scoreText.text) - score);
	}
	
	public void setScore ( float score ){
		savedScore = score; 
		scoreText.text = score.ToString ();
		if (score >= winScore) {
			GameObject.Find("levelController").GetComponent<levelController>().loadScene("Win");
		}
	}
	
	public void resetScore(){
		setScore (0);
	}
	/// <summary>
	/// Adds the health.
	/// </summary>
	/// <param name="health">Health.</param>
	public void addHealth ( float health ){
		setHealth (float.Parse (healthText.text) + health);
	}
	
	public void subHealth ( float health ){
		setHealth (float.Parse (healthText.text) - health);
	}
	
	public void setHealth ( float health ){
		healthText.text = health.ToString ();
	}
	
	public void resetHealth(){
		setHealth (500f);
	}

	public static float getScore(){
		return savedScore;
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start (){
		resetScore ();
		setHealth (player.GetComponent<playerController>().Health);
	}

}
