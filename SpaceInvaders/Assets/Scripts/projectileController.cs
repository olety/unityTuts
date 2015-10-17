using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour {
	public float projectileHeight;
	public float damage;
	private float maxY, minY;

	public float getDamage(){
		return damage;
	}

	// Use this for initialization
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 topCam = Camera.main.ViewportToWorldPoint (new Vector3(0,1,distance));
		Vector3 botCam = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		maxY = topCam.y + projectileHeight / 2;
		minY = botCam.y - projectileHeight / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y >= maxY || this.transform.position.y <= minY) {
			Destroy(this.gameObject, 0.0f);
		}
	}
}