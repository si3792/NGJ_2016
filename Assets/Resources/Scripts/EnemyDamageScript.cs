using UnityEngine;
using System.Collections;

public class EnemyDamageScript : MonoBehaviour {


	float health = 50;
	public float biomassSpawnChance = 0.6f;
	bool died = false;
	public GameObject biomassDrop;
	public GameObject psFx;

	void Start () {
	
	}

	// For use from external sources
	public void Damage(float dmg) {
		health -= dmg;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag  == "Bullet") {
			health -= other.gameObject.GetComponent<BulletMovement> ().damage;
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "Explosion") {
			health = -1;
		}
	}

	void OnCollisionStay2D(Collision2D other) {
		Debug.Log(other.gameObject.tag);
		if (other.collider.gameObject.tag == "Explosion") {
			health = -1;
		}
	}

	void Update() {
		if (health <= 0 && died == false) {

			//chance to spawn biomass nugget
			if(Random.value > biomassSpawnChance) {
				Instantiate (biomassDrop, transform.position, Quaternion.Euler (Vector3.zero));
			}
			//ps
			Instantiate(psFx, transform.position, Quaternion.Euler(Vector3.zero));

			died = true;
			Destroy (gameObject.transform.parent.gameObject);
		}
	}


}
