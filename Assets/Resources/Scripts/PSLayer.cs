using UnityEngine;
using System.Collections;

public class PSLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "psLayer";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
