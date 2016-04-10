using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	public void shipFueled() {
		anim.SetBool ("ShipFueled", true);
	}

	public void liftoff() {
		anim.SetBool ("PlayerIn", true);
	}

}
