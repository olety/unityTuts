using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int countBreakable = 0;
	public AudioClip blockDestroyedSound;
	public GameObject Smoke;

	private int timesHit;
	private levelController controller;
	private bool isBreakable;

	public void Start() {
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		//Keeping track of breakable bricks
		if (isBreakable) {
			countBreakable++;
			Debug.Log(countBreakable);
		}
		// Assigning controller variable to levelController in the scene
		controller = GameObject.FindObjectOfType<levelController> ();
	}

	public void OnCollisionEnter2D ( Collision2D collision ){
		// If the block is breakable and we've hit it with the ball, handle its hit
		if (isBreakable) {
			handleHits ();
		}
	}

	private void handleHits() {
		// If we've hit it enough times, destroy it. Otherwise, make it look hit
		if (++timesHit > hitSprites.Length) {
			// Make a smoke at the position of block, with the color of the said brick
			Vector3 smokePos = new Vector3 (this.transform.position.x, this.transform.position.y, -1);
			Smoke.particleSystem.startColor = GetComponent<SpriteRenderer>().color;
			Instantiate(Smoke, smokePos, Quaternion.identity);
			// Play a brick destroyed sound
			AudioSource.PlayClipAtPoint(blockDestroyedSound, this.transform.position, 0.2f);
			// Decrement the breakable block count
			countBreakable--;
			// Call blockDestroyed method that will check if we've won
			controller.blockDestroyed();
			// Destroy the brick
			Destroy (gameObject);
		} else {
			loadSprites();
		}
	}
	private void loadSprites() {
		// Change sprite from "healthy" to hit"
		Sprite nextSprite = hitSprites [timesHit - 1];
		// If said sprite exists, change it, otherwise log an error
		if (nextSprite) {
			this.GetComponent<SpriteRenderer> ().sprite = nextSprite;
		} else {
			Debug.LogError("Block sprite missing!");
		}
	}

}
