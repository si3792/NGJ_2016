using UnityEngine;
using System.Collections;

public class SchootScriptPL2 : MonoBehaviour {

	public Transform muzzleTip;
	public GameObject bullet;
	public GameObject muzzleFlash;
	GameObject gun;
	public float deviation = 1;
	public AudioClip shootSound;
	public float selfKnockback = 8f;

	GameObject pl;


	void Start () {



		gun = GameObject.FindGameObjectWithTag("pl2-gun");
		pl = GameObject.FindGameObjectWithTag("Pl2");

		if (GlobalData.p2Knockback)
			selfKnockback += GlobalData.p2KnockbackAmount;

		selfKnockback *= pl.GetComponent<Rigidbody2D> ().mass;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Shoot() {

		// Randomize sound
		if(GlobalData.soundFXOn) {
		this.gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.6f, 1.4f); 

		this.gameObject.GetComponent<AudioSource>().PlayOneShot(shootSound);
		}

		GameObject reff;

		if (transform.parent.gameObject.GetComponent<PlayerMovement> ().GetFacingRight ()) {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 180 + Random.Range(-deviation, deviation))));
			pl.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-selfKnockback, 0), ForceMode2D.Impulse);
			reff = (GameObject) Instantiate (muzzleFlash, gun.transform.position, Quaternion.Euler (new Vector3(0, 0, 0)));
		} else {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 0 + Random.Range(-deviation, deviation))));
			pl.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (selfKnockback, 0), ForceMode2D.Impulse);
			reff = (GameObject) Instantiate (muzzleFlash, gun.transform.position, Quaternion.Euler (new Vector3(0, 180, 0)));
		}


		reff.transform.SetParent (gun.transform);
	}

}
