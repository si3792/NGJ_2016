using UnityEngine;
using System.Collections;

public class varySound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().pitch = Random.Range (0.75f, 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
