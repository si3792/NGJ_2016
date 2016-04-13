using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	Animator anim;
	int playersIn = 0;
	bool readyToFly = false;
	bool liftoff_flag = false;




	public void ready() {
		readyToFly = true;
	}

	void Start() {
		anim = GetComponent<Animator> ();
	}

	public void shipFueled() {
		anim.SetBool ("ShipFueled", true);
	}

	public void liftoff() {
		var cam = GameObject.FindGameObjectWithTag("PerspectiveCameraSupervisor").GetComponent<PerspectiveCameraSupervisor>();
		cam.FocusCameraOnPoint(new Vector2(transform.position.x - 5, transform.position.y + 3), 20, CameraId.main, 12f);
		GameObject.FindGameObjectWithTag("psaiTogether").SetActive(false);
		anim.SetBool ("PlayerIn", true);
		liftoff_flag = true;
	}

	public void startEngines() {

		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Engine")) {
			go.GetComponent<ParticleSystem> ().Play ();
		}

		gameObject.GetComponent<AudioSource> ().Play ();
	}



	public void FixedUpdate() {

		//Win condition
		if(liftoff_flag)return;

		if (playersIn == 2)
			liftoff ();

		if(playersIn == 1 && (PlayerMovement.player1Alive == false && PlayerMovement.player2Alive == false )  )
			liftoff ();
	}

	public void OnTriggerStay2D(Collider2D other) {


		if( readyToFly ) {
			if(other.gameObject.tag == "Pl1" || other.gameObject.tag == "Pl2") {

				Destroy (other.gameObject);
				playersIn++;

			}

		}

	}

}
