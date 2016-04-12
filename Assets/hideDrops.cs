using UnityEngine;
using System.Collections;

public class hideDrops : MonoBehaviour {

	GameObject ship, droplet;


	// Use this for initialization
	void Start () {
		ship = GameObject.FindGameObjectWithTag ("the-ship");
		droplet = transform.Find ("Droplet").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(ship == null) {
			Destroy (this.gameObject);
			return;
		}

		NuggetHandler nh = ship.GetComponent<NuggetHandler> ();
		if(nh == null)  {
			droplet.SetActive (false);
			return;
		}

		if(nh.nuggets <= 0 || nh.nuggets >= nh.NuggetsToWin ) {
			droplet.SetActive (false);
		} else {
			droplet.SetActive (true);
		}

	}
}

