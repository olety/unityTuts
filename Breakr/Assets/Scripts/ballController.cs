using UnityEngine;
using System.Collections;

public class ballController : MonoBehaviour {

	private paddleController paddle;
	private Vector3 paddleBallVector;
	private bool gameStarted = false;

	// Use this for initialization
	void Start () {
		// Find our paddle
		paddle = GameObject.FindObjectOfType<paddleController>();
		// Set the position of the transform to the pos above the paddle so it would "stick"
		paddleBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// If the game hasn't started, then stick the ball to the paddle and launch it on key press
		if (!gameStarted) {
			this.transform.position = paddle.transform.position + paddleBallVector;
			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {
				Debug.Log ("Mouse clicked, launching the ball");
				this.rigidbody2D.velocity = new Vector2 (Random.Range(-4f,4f), 10f);
				gameStarted = true;
			}
		}
	}

	void OnCollisionEnter2D ( Collision2D collision ){
		// Change the velocity of the ball to random velocity between its velocity +- 0.3f because otherwise game might loop
		this.rigidbody2D.velocity = new Vector2( Mathf.Clamp(this.rigidbody2D.velocity.x+Random.Range (-0.3f, 0.3f),-8,8),
		                                        Mathf.Clamp(this.rigidbody2D.velocity.y+Random.Range(-0.3f, 0.3f),-13,13));
		// If we've started the game, play the collision sound
		if ( gameStarted )
			audio.Play ();
	}
}
