using UnityEngine;
using System.Collections;

public class deathXScript : MonoBehaviour {

	public bool playerOne;

	void Start () {
		if(GlobalData.p1survived == false && playerOne) {
			GetComponent<SpriteRenderer> ().enabled = true;	
		}

		if(GlobalData.p2survived == false && playerOne == false) {
			GetComponent<SpriteRenderer> ().enabled = true;	
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
