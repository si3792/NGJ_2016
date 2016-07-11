using UnityEngine;
using System.Collections;

public class GunOverheatMaskDepth : MonoBehaviour {

	public GameObject gunTarget;
	private SpriteRenderer mySR;
	// Use this for initialization
	void Start () {
		mySR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {

		mySR.sortingOrder = gunTarget.GetComponent<SpriteRenderer> ().sortingOrder + 1;
	}
}
