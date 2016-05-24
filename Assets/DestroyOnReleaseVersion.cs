using UnityEngine;
using System.Collections;

public class DestroyOnReleaseVersion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Awake() {
		if(!GlobalData.developerBuild) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
