﻿using UnityEngine;
using System.Collections;

public class MineController : MonoBehaviour {

	public GameObject explosion;
	public float damage;
	public float explosionRadius;

	public AudioClip explosionSound;
	public GameObject soundPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag  == "enemy-hurtbox") {
			var player = Instantiate(soundPlayer);
			player.GetComponent<SingleSound>().clip = explosionSound;

			GameObject.Instantiate(explosion, transform.position, transform.rotation);
			var hits = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), explosionRadius);
			foreach (var collider in hits) {
				if (collider.gameObject.tag == "enemy-hurtbox") {
					collider.gameObject.GetComponent<EnemyDamageScript>().Damage(damage);
					collider.gameObject.GetComponent<EnemyDamageScript> ().lastDMGPl1 = true;
				}
			}
			Destroy (this.gameObject);
		}
	}
}
