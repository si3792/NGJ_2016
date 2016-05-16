using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float health = 100f;
	public float MaxHP = 0f;
	GameObject MainCam, SecondCam;
	CameraTellerScript cts;

	void Start () {
		
		MainCam = GameObject.FindGameObjectWithTag ("MainCamera");

		if(transform.parent.tag == "Pl2"  ) {
			SecondCam = GameObject.FindGameObjectWithTag("CameraP1");

			if (GlobalData.p2armor == true)
				health += GlobalData.armorAmount;

		} else 

			if (GlobalData.p1armor == true)
				health += GlobalData.armorAmount;

			SecondCam = GameObject.FindGameObjectWithTag("CameraP2");

		cts = GameObject.FindGameObjectWithTag ("CameraTeller").GetComponent<CameraTellerScript>();


		if (MaxHP == 0) {
			MaxHP = health;
		}
	}
		

	void Update () {

		if(health <= 0) {
			GlobalData.Players--;
			Destroy (transform.parent.gameObject);

			Debug.Log ("Global data " + GlobalData.Players);
			if (GlobalData.Players <= 0) {
				// End Game

				GameObject.FindGameObjectWithTag ("Screenfader").GetComponent<ScreenfaderScript> ().sceneEnding = true;
				Debug.Log ("KUR");
			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "BeetleHurt") {
			//transform.parent.GetComponent<PlayerMovement> ().knockback (60, new Vector2 (transform.position.x - other.gameObject.transform.position.x, 0f));
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "BeetleHurt") {
			//transform.parent.GetComponent<PlayerMovement> ().knockback (60, new Vector2 (transform.position.x - other.gameObject.transform.position.x, 0f));
			health -= 3 * Time.fixedDeltaTime;

			bool flag = (transform.parent.tag == "Pl1") ? true : false;
			MainCam.GetComponent<pulseCamera> ().MakeMePulse (0.2f);
			SecondCam = cts.getCameraForPlayer( flag);
			SecondCam.GetComponent<pulseCamera> ().MakeMePulse (0.2f);
		}
	}

}
