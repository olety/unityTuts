using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Guessr : MonoBehaviour {
	public int min = 1, max = 1000, guessCount = 5;
	public string winScene, loseScene;
	public Text guessText, countText;
//	private int minUsable, maxUsable;
	private int guess;

	public void guessHigher() {
		min = guess;
		nextGuess ();	
	}

	public void guessLower() {
		max = guess;
		nextGuess ();
	}

	public void guessCorrect(){
		Application.LoadLevel (loseScene);
	}

	void startGame(){
		max++;
		guess = Random.Range (min, max);
		guessText.text = guess.ToString();
		countText.text = "Guesses left : " + guessCount.ToString ();
	}

	void nextGuess(){
		if ( --guessCount <= 0) {
			Application.LoadLevel(winScene);
		} else {
			Debug.Log("Max Usable = " + max + "\nMin Usable = " + min);
			countText.text = "Guesses left : " + guessCount.ToString ();
			guess = Random.Range (min, max);
			if ( min == max )
				guess = min;
			guessText.text = guess.ToString();
		}
	}

	void Start () {
		startGame ();
	}
}
