using UnityEngine;
using System.Collections;

public class ChangeSceneBars : MonoBehaviour {

	public float delay;
	GameObject sf;

	void Start() {
		sf = GameObject.FindGameObjectWithTag ("Screenfader");
	}

	void go() {
		//sf.GetComponent<ScreenfaderScript> ().sceneEnding = true;
		// WHY SO BUGGY? ^^
		Application.LoadLevel("score-scene"); 
	}

	public void startChange(){
		Invoke ("go", delay);
	}
}
