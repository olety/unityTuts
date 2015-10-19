using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	
	public float horizontalVelocity;
	public float verticalVelocity;
	public float offsetX, offsetY;
	public GameObject projectile;
	public float projectileSpeed;
	public float projectileFireDelay;
	public float projectileOffset;
	public float Health;
	public AudioClip deathSound;
	public AudioClip hitSound;
	public AudioClip fireSound;
	private Vector2 min, max;
	private scoreKeeper scorekp;

	private void Hit( float damage ){
		AudioSource.PlayClipAtPoint (hitSound, this.transform.position);
		Health -= damage;
		scorekp.setHealth (Health);
		if (Health <= 0) {
			Die ();
		}
	}

	void Die(){
		AudioSource.PlayClipAtPoint (deathSound, this.transform.position);
		GameObject.Find ("levelController").GetComponent<levelController> ().loadScene("Lose");
		Destroy (this.gameObject,0.000001f);
	}

	void OnTriggerEnter2D(Collider2D collider){
		projectileController projectile = collider.gameObject.GetComponent<projectileController> ();
//		Debug.Log (projectile.gameObject.name);
		if (projectile.gameObject.name == "enemyProjectile(Clone)") {
			Hit( projectile.getDamage() );
			Destroy (projectile.gameObject);
		}
	}

	void Start () {
		scorekp = GameObject.Find ("ScoreKeeper").GetComponent<scoreKeeper> ();
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftCam = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		Vector3 rightCam = Camera.main.ViewportToWorldPoint (new Vector3(1,1,distance));
		min = leftCam;
		max = rightCam;
	}

	void Fire(){
//		Debug.Log("Shots fired1");
		AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
		GameObject laser = Instantiate(projectile, 
		                               new Vector3(this.transform.position.x, this.transform.position.y+projectileOffset), 
		                               Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);
	}

	void Update () {

		this.transform.position =  new Vector3 (Mathf.Clamp(this.transform.position.x + Time.deltaTime*Input.GetAxisRaw("Horizontal")*horizontalVelocity,min.x+offsetX,max.x-offsetX),
		                                        Mathf.Clamp(this.transform.position.y + Time.deltaTime*Input.GetAxisRaw("Vertical")*horizontalVelocity,min.y+offsetY,max.y-offsetY), 
		                                        this.transform.position.z);	
		if (Input.GetButtonDown("Fire1")){
			InvokeRepeating("Fire", 0.0000001f, projectileFireDelay);
		}
		if (Input.GetButtonUp("Fire1")){
			CancelInvoke("Fire");
		}
	}
}
