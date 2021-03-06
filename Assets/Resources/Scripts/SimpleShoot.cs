﻿using UnityEngine;
using System.Collections;

public class SimpleShoot : MonoBehaviour
{

	public float FireRate = 0.3f;
	public float deviation;
	public GameObject bullet;
	public Transform muzzleTip;
	float nextFire = 0;

	// tmp reference to instantiated bullet
	GameObject reff;

	// Update is called once per frame
	void FixedUpdate ()
	{	
		if ((Input.GetKey(KeyCode.Space) || Input.GetAxis("RightTriggerP2") > 0) && Time.timeSinceLevelLoad > nextFire) {

			nextFire = Time.timeSinceLevelLoad + FireRate;

			if (gameObject.GetComponent<PlayerMovement>().FacingRight) {
				reff = (GameObject)Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 180 + Random.Range(-deviation, deviation))));
			} else {
				reff = (GameObject)Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 0 + Random.Range(-deviation, deviation))));
			}

			reff.GetComponent<RandomizeSpriteOnCommand> ().randomize ();
		}
	
	}
}
