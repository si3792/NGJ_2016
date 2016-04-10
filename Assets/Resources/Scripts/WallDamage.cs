﻿using UnityEngine;
using System.Collections;

public class WallDamage : MonoBehaviour {

	public float health = 100.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0.0f) {
			Destroy (transform.parent.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "BeetleHurt") {
			//transform.parent.GetComponent<PlayerMovement> ().knockback (60, new Vector2 (transform.position.x - other.gameObject.transform.position.x, 0f));
			health -= 10.0f * Time.fixedDeltaTime;
		}
	}
}