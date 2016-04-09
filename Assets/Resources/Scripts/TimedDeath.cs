using UnityEngine;
using System.Collections;

public class TimedDeath : MonoBehaviour {

	public float TimeToLive;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, TimeToLive);
	}

}
