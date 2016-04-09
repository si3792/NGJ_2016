using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float health = 100;

	void Start () {
		
	}
	

	void Update () {

		if(health <= 0) {
			Destroy (transform.parent.gameObject);
		}
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "BeetleHurt") {
			//transform.parent.GetComponent<PlayerMovement> ().knockback (60, new Vector2 (transform.position.x - other.gameObject.transform.position.x, 0f));
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "BeetleHurt") {
			//transform.parent.GetComponent<PlayerMovement> ().knockback (60, new Vector2 (transform.position.x - other.gameObject.transform.position.x, 0f));
			health -= 10 * Time.fixedDeltaTime;
		}
	}

}
