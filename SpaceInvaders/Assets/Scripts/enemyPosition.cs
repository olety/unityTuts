using UnityEngine;
using System.Collections;

public class enemyPosition : MonoBehaviour {
	public float gizmoRadius;
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (this.transform.position, gizmoRadius);
	}

}
