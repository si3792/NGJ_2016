using UnityEngine;
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


		if (Input.GetKey (KeyCode.Space) && Time.timeSinceLevelLoad > nextFire) {

			nextFire = Time.timeSinceLevelLoad + FireRate;

			if (gameObject.GetComponent<PlayerMovement> ().GetFacingRight ()) {
				reff = (GameObject)Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, -90 + Random.Range(-deviation, deviation))));
			} else {
				reff = (GameObject)Instantiate (bullet, muzzleTip.position, Quaternion.Euler (new Vector3(0, 0, 90 + Random.Range(-deviation, deviation))));
			}

			reff.GetComponent<RandomizeSpriteOnCommand> ().randomize ();
		}
	
	}
}
