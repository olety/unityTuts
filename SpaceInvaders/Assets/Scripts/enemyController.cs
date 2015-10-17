using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	public float health;
	public GameObject projectile;
	public float projectileSpeed;
	public float projectileFireRate;
	public float projectileOffset;
	private levelController controller;
//	public float projectileFireRate;
	
	void Hit( float damage ){
		if (controller.enemiesRespawning == false) {
			health -= damage;
			if (health <= 0) {
				Destroy (this.gameObject, 0.000001f);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		projectileController projectile = collider.gameObject.GetComponent<projectileController> ();
//		Debug.Log (projectile.gameObject.name);
		if (projectile.gameObject.name == "playerProjectile(Clone)") {
			Hit( projectile.getDamage() );
			Destroy (projectile.gameObject);
		}
	}
	void Fire(){
		GameObject laser = Instantiate(projectile, 
		                               new Vector3(this.transform.position.x, this.transform.position.y-projectileOffset), 
		                               Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3(0,-projectileSpeed,0);
	}

	void Start(){
//		Find out level controller
		controller = FindObjectOfType<levelController> ();
	}

	void Update(){
		if (controller.gameStarted == true ) {
			float chanceOfFiring = Time.deltaTime * projectileFireRate;
			if ( Random.value < chanceOfFiring && controller.enemiesRespawning == false){
				Fire();
			}
		}
	}

}
