using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float formationWidth;
	public float formationHeight;
	public float horizontalVelocity;
//	public float verticalVelocity;
	private float minX, maxX;
	public float spawnDelay;
	private levelController controller;
	private float vertDirection = 1.0f; // 1 = right, -1 = left
	// Use this for initialization
	void Start () {
		controller = FindObjectOfType<levelController> ();
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftCam = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		Vector3 rightCam = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distance));
		minX = leftCam.x + formationWidth/2;
		maxX = rightCam.x - formationWidth/2;
		SpawnEnemies ();
	}

	void SpawnEnemies(){
		foreach ( Transform child in this.transform ){
			if ( child.name == "Position" ){
				GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
				enemy.transform.parent = child;
			}
		}
	}

	void SpawnUntillFull(){
		Transform nextPos = NextFreePosition ();
		if (nextPos) { 
			GameObject enemy = Instantiate (enemyPrefab, nextPos.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = nextPos;
		} 
		if (NextFreePosition () != null) {
			Invoke ("SpawnUntillFull", spawnDelay);
		} else {
			controller.enemiesRespawning = false;
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (this.transform.position, new Vector3(formationWidth, formationHeight,0));
	}

	bool AllMembersDead(){
		foreach (Transform childPosition in transform) {
			if ( childPosition.childCount > 0 ){
				return false;
			}
		}
		return true;
	}

	Transform NextFreePosition(){
		foreach (Transform childPosition in transform) {
			if ( childPosition.childCount == 0 ){
				return childPosition;
			}
		}
		return null;
	}

	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (Mathf.Clamp(this.transform.position.x + 
		                                       vertDirection*horizontalVelocity * Time.deltaTime,minX,maxX),
		                                       this.transform.position.y);
		if (this.transform.position.x == maxX || this.transform.position.x == minX) {
			vertDirection = -vertDirection;
		}
		if (AllMembersDead ()) {
			Debug.Log("All enemies rekt");
			controller.enemiesRespawning = true;
			SpawnUntillFull();
		}
	}
}
