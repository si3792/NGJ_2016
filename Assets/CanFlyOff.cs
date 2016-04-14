using UnityEngine;
using System.Collections;

public class CanFlyOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	float alpha = 1f;
	bool activated = false;
	// Update is called once per frame
	void FixedUpdate () {
		if(gameObject.GetComponent<Rigidbody2D>() != null && activated == false) {
			var rb = gameObject.GetComponent<Rigidbody2D> ();
			rb.AddForce (new Vector2 (Random.Range (-3f, 3f), Random.Range(5f, 7f)), ForceMode2D.Impulse);
			rb.AddTorque (Random.Range(0, 8f), ForceMode2D.Impulse);
			activated = true;


			Destroy (this.gameObject, 2.5f);

		}

		if(activated && alpha > 0) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, alpha);
			alpha -= 0.01f;
		}
	
	}
}
