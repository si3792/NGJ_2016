using UnityEngine;
using System.Collections;

public class VolumeCtrl : MonoBehaviour {


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<AudioSource> ().mute = !GlobalData.soundFXOn;
	}
}
