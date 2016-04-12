using UnityEngine;
using System.Collections;

public class hideDrops : MonoBehaviour {

	GameObject ship;


	// Use this for initialization
	void Start () {
		ship = GameObject.FindGameObjectWithTag ("the-ship");
	}
	
	// Update is called once per frame
	void Update () {
		if(ship == null) {
			Destroy (this.gameObject);
		}

		NuggetHandler nh = ship.GetComponent<NuggetHandler> ();
		if(nh.nuggets <= 0 || nh.nuggets >= nh.NuggetsToWin ) {
			gameObject.GetComponent<Animator> ().enabled = false;
		} else {
			gameObject.GetComponent<Animator> ().enabled = true;
		}

	}
}
