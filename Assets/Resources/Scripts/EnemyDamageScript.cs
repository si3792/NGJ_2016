using UnityEngine;
using System.Collections;

public class EnemyDamageScript : MonoBehaviour {


	float health = 50;
	bool died = false;
	public GameObject biomassDrop;
	public GameObject psFx;

	void Start () {
	
	}


	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag  == "Bullet") {
			health -= other.gameObject.GetComponent<BulletMovement> ().damage;
			Destroy (other.gameObject);
		}

		if (health <= 0 && died == false) {

			//chance to spawn biomass nugget
			if(Random.value > 0.6)
			Instantiate (biomassDrop, transform.position, Quaternion.Euler (Vector3.zero));

			//ps
			Instantiate(psFx, transform.position, Quaternion.Euler(Vector3.zero));

			died = true;
			Destroy (gameObject.transform.parent.gameObject);
		}

	}


}
