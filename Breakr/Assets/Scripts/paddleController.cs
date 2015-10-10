using UnityEngine;
using System.Collections;

public class paddleController : MonoBehaviour {

	public float minX, maxX;
	private ballController ball;

	// Find our ball
	void Start () {
		ball = FindObjectOfType<ballController> ();
	}

	void Update () {
		// If user turned autoMode on, handle movement in MoveAuto(). Otherwise, in MoveWithMouse()
		if (levelController.autoPlay) {
			MoveAuto();
		} else {
			MoveWithMouse();
		}
	}
	
	void MoveWithMouse (){
		// We need to multiply by 16 because our play space is 16 units wide. 
		float mousePosBlocksX = 16f * Input.mousePosition.x / Screen.width;
		// Set our position to the mouse position with some limitations
		this.transform.position =  new Vector3 (Mathf.Clamp (mousePosBlocksX, minX, maxX),
		                                        this.transform.position.y, 
		                                        this.transform.position.z);		
	}

	void MoveAuto (){
		// Set our position to the ball position with some limitations
		this.transform.position = new Vector3 (Mathf.Clamp(ball.transform.position.x,minX,maxX),
		                                       this.transform.position.y,
		                                       this.transform.position.z);
	}
}
