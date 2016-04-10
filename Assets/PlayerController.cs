using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float health = 100f;
	public float MaxHP = 0f;

	void Start () {
		if (MaxHP == 0) {
			MaxHP = health;
		}	
	}
	

	void Update () {

		if(health <= 0) {
			GlobalData.Players--;
			Destroy (transform.parent.gameObject);
			if (GlobalData.Players <= 0) {
				Application.LoadLevel("MenuScene");
			}
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
			health -= 3 * Time.fixedDeltaTime;
		}
	}

}
