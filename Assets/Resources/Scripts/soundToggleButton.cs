using UnityEngine;
using System.Collections;

public class soundToggleButton : MonoBehaviour {

	public bool buttonOn;
	// Use this for initialization
	void Start () {
		if (GlobalData.musicOn) {
			if (buttonOn)
				gameObject.SetActive (true);
			else gameObject.SetActive (false);
		} else {
			if (buttonOn)
				gameObject.SetActive (false);
			else gameObject.SetActive (true);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
