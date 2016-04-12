using UnityEngine;
using System.Collections;

public class HideSpaceship : MonoBehaviour {

	public void hideShip() {
		
		Destroy (transform.parent.gameObject);
	}
}
