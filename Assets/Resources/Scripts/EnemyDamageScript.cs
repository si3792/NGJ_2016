using UnityEngine;
using System.Collections;

public class EnemyDamageScript : MonoBehaviour {


	float health = 50;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0)
			Destroy (gameObject.transform.parent.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag  == "Bullet") {
			health -= other.gameObject.GetComponent<BulletMovement> ().damage;
			Destroy (other.gameObject);
		}
	}


}
