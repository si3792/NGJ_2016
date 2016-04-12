using UnityEngine;
using System.Collections;

public class SingleSound : MonoBehaviour {

	public AudioClip clip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (clip != null) {
			var source = this.gameObject.GetComponent<AudioSource>();
			source.PlayOneShot(clip);
			clip = null;
		}
	}
}
