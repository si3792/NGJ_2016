using UnityEngine;
using System.Collections;

public class TintOnDeath : MonoBehaviour {

	public bool isPlayerOne;

	void Start () {
		if(GlobalData.p1survived == false && isPlayerOne) {
			GetComponent<SpriteRenderer> ().color = Color.black;
		}
		else 
		if(GlobalData.p2survived == false && isPlayerOne == false) {
			GetComponent<SpriteRenderer> ().color = Color.black;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
