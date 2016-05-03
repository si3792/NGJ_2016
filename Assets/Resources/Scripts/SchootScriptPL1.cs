using UnityEngine;
using System.Collections;

public class SchootScriptPL1 : MonoBehaviour {

	public Transform muzzleTip;
	public GameObject bullet;
	public float deviation = 1;
	public AudioClip shootSound;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void Shoot2() {

		// Randomize sound

		if(GlobalData.soundFXOn) {
		this.gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f); 

		this.gameObject.GetComponent<AudioSource>().PlayOneShot(shootSound);
		}

		if (transform.parent.parent.gameObject.GetComponent<PlayerMovement>().GetFacingRight ()) {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 180 + Random.Range(-deviation, deviation))));
		} else {
			Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 0 + Random.Range(-deviation, deviation))));
		}
	}
}
