using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

	public float shieldDuration;
	public float shieldTimeout;
	float curTimeout = 0;


	public GameObject hbox;
	// Use this for initialization
	void Start () {
		disable ();

		if(GlobalData.p1shield == false) {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		curTimeout -= Time.deltaTime;
	}

	public void attemptShields() {
		if(curTimeout <= 0) {
			enable ();
			Invoke ("disable", shieldDuration);
			curTimeout = shieldTimeout;
		}
	}

	void enable() {
		GetComponent<SpriteRenderer> ().enabled = true;
		hbox.GetComponent<PlayerController> ().invulnerable = true;
	}

	void disable() {
		GetComponent<SpriteRenderer> ().enabled = false;
		hbox.GetComponent<PlayerController> ().invulnerable = false;
	}


}
