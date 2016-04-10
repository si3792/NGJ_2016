using UnityEngine;
using System.Collections;

public class EnemyDamageScript : MonoBehaviour {


	public float health = 50;
	public float biomassSpawnChance = 0.6f;
	bool died = false;
	public GameObject biomassDrop;
	public GameObject psFx;
	public float pl2BulletDamage;
	public GameObject explosion;

	void Start () {
	
	}

	// For use from external sources
	public void Damage(float dmg) {
		health -= dmg;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag  == "Bullet") {
			health -= other.gameObject.GetComponent<BulletMovement> ().damage;

			if( other.gameObject.GetComponent<BulletMovement> ().damage == pl2BulletDamage) {
				Instantiate (explosion, other.transform.position, Quaternion.Euler (Vector3.zero));
			}
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
