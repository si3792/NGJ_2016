using UnityEngine;
using System.Collections;

public class SchootScriptPL2 : MonoBehaviour {

	public Transform muzzleTip;
	public GameObject bullet;
	public GameObject muzzleFlash;
	GameObject gun;
	public float deviation = 1;
	public AudioClip shootSound;
	GameObject pl;

	void Start () {
		gun = GameObject.FindGameObjectWithTag("pl2-gun");
		pl = GameObject.FindGameObjectWithTag("Pl2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Shoot() {
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(shootSound);
		GameObject reff;

		if (transform.parent.gameObject.GetComponent<PlayerMovement> ().GetFacingRight ()) {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 180 + Random.Range(-deviation, deviation))));
			pl.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-8f, 0), ForceMode2D.Impulse);
			reff = (GameObject) Instantiate (muzzleFlash, gun.transform.position, Quaternion.Euler (new Vector3(0, 0, 0)));
		} else {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 0 + Random.Range(-deviation, deviation))));
			pl.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (8f, 0), ForceMode2D.Impulse);
			reff = (GameObject) Instantiate (muzzleFlash, gun.transform.position, Quaternion.Euler (new Vector3(0, 180, 0)));
		}


		reff.transform.SetParent (gun.transform);
	}

}
