﻿using UnityEngine;
using System.Collections;

public class EnemyDamageScript : MonoBehaviour {


	float health = 50;
	public GameObject biomassDrop;

	void Start () {
	
	}


	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag  == "Bullet") {
			health -= other.gameObject.GetComponent<BulletMovement> ().damage;
			Destroy (other.gameObject);
		}

		if (health <= 0) {
			Instantiate (biomassDrop, transform.position, Quaternion.Euler (Vector3.zero));
			Destroy (gameObject.transform.parent.gameObject);
		}

	}


}
