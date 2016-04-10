using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	Animator anim;
	int playersIn = 0;
	bool readyToFly = false;

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
		cam.FocusCameraOnPoint(new Vector2(transform.position.x - 30, transform.position.y + 50), 10, CameraId.main, 30);
		anim.SetBool ("PlayerIn", true);
	}




	public void OnTriggerEnter2D(Collider2D other) {


		if( readyToFly ) {
			if(other.gameObject.tag == "Pl1" || other.gameObject.tag == "Pl2") {

				Destroy (other.gameObject);
				playersIn++;

				if (playersIn == 2)
					liftoff ();

				if(playersIn == 1 && (PlayerMovement.player1Alive == false || PlayerMovement.player2Alive == false )  )
					liftoff ();

			}

		}

	}

}
