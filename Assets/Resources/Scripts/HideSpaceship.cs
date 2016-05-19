using UnityEngine;
using System.Collections;

public class HideSpaceship : MonoBehaviour {

	public void hideShip() {
		Destroy (this.gameObject);
	}

	public void changeScene() {
		GameObject.FindGameObjectWithTag ("Screenfader").GetComponent<ScreenfaderScript> ().sceneEnding = true;
	}
}
