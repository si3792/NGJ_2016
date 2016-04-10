using UnityEngine;
using System.Collections;

public class SchootScriptPL2 : MonoBehaviour {

	public Transform muzzleTip;
	public GameObject bullet;
	public GameObject muzzleFlash;
	GameObject gun;
	public float deviation = 1;
	void Start () {
		gun = GameObject.FindGameObjectWithTag("pl2-gun");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Shoot() {
		GameObject reff;

		if (transform.parent.gameObject.GetComponent<PlayerMovement> ().GetFacingRight ()) {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 180 + Random.Range(-deviation, deviation))));

			reff = (GameObject) Instantiate (muzzleFlash, gun.transform.position, Quaternion.Euler (new Vector3(0, 0, 0)));
		} else {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 0 + Random.Range(-deviation, deviation))));

			reff = (GameObject) Instantiate (muzzleFlash, gun.transform.position, Quaternion.Euler (new Vector3(0, 180, 0)));
		}


		reff.transform.parent = gun.transform;
	}

}
