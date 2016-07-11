using UnityEngine;
using System.Collections;

public class SchootScriptPL1 : MonoBehaviour {

	public Transform muzzleTip;
	public GameObject bullet;
	public float deviation = 1;
	public AudioClip shootSound;
	public float overheatStep = 1f, overheatCoolStep = 0.2f,  overheatClearLock = 10f;



	void Start () {

	}


	void Update () {
		GlobalData.overheatPercent = Mathf.Max (GlobalData.overheatPercent - overheatCoolStep * Time.deltaTime, 0f);

		if (GlobalData.overheatPercent >= 100f)
			GlobalData.overheatLock = true;

		if (GlobalData.overheatPercent < overheatClearLock)
			GlobalData.overheatLock = false;


	}

	void Shoot2() {

		if(GlobalData.overheatLock)return;
		GlobalData.overheatPercent += overheatStep;

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
