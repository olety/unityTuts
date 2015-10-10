using UnityEngine;
using System.Collections;

public class Guessr : MonoBehaviour {
	public int min = 1, max = 1000;
	private int minUsable, maxUsable;
	private int guess;
	private string guessUp = "guessUp", guessDown = "guessDown", guessRight = "guessRight";

	void startGame(){

		maxUsable = max + 1;
		minUsable = min - 1;
		guess = Random.Range (minUsable, maxUsable+1);
		print ("============================================================");
		print ("Welcome to Guessr");
		print ("Pick a number in your head, but don't tell me ;)");
		print ("Maximum number you can pick is " + max + "\nMinimum number you can pick is " + min);
		print ("============================================================");
		print ("Is the number higher or lower than " + guess + "?");
		print ("Use Up key for higher, Down key for lower, Enter key for equal.");

	}

	void nextGuess(){
		guess = Random.Range (minUsable, maxUsable);
		print ("Is the number higher or lower than " + guess + "?");
		print ("Use Up key for higher, Down key for lower, Enter key for equal.");
	}

	void Start () {
		startGame ();
	}

	void Update () {

		if (Input.GetButtonDown (guessUp)) {
			// print ("Up");
			minUsable = guess;
			nextGuess ();
		} else if (Input.GetButtonDown (guessDown)) {
			// print ("Down");
			maxUsable = guess;
			nextGuess();
		} else if (Input.GetButtonDown (guessRight)){
			print ("I WON!!! MUHAHAHHA");
			print ("Restarting the gaem...");
			startGame();
		}
	}
}
