using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplitLineControl : MonoBehaviour {

	Image line;
	Camera mainCam;
	// Use this for initialization
	void Start () {
		line = this.gameObject.GetComponent<Image>();
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		line.enabled = !mainCam.enabled;
	}
}
