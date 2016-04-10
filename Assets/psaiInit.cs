using UnityEngine;
using System.Collections;

public class psaiInit : MonoBehaviour {

	public GameObject go;

	void Awake () {
		Instantiate (go, new Vector3 (10000f, 10000f, 10000f), transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
