using UnityEngine;
using System.Collections;

public class SortByDepth : MonoBehaviour {

	SpriteRenderer mySR;
	Transform depthChecker;

	void Start() {
		mySR = GetComponent<SpriteRenderer> ();	

		// !! All users of this script must have this 
		depthChecker = transform.Find ("depth-checker");
	}
	
	void Update () {

		mySR.sortingOrder = (int) (depthChecker.position.y * -100f );
	
	}
}
