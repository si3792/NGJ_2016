using UnityEngine;
using System.Collections;

public class SchootScriptPL2 : MonoBehaviour {

	public Transform muzzleTip;
	public GameObject bullet;
	public float deviation = 1;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot() {

		if (transform.parent.gameObject.GetComponent<PlayerMovement> ().GetFacingRight ()) {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 180 + Random.Range(-deviation, deviation))));
		} else {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 0 + Random.Range(-deviation, deviation))));
		}
	}

}
