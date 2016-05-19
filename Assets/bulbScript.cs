using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bulbScript : MonoBehaviour {

	public int myMode;
	Image img;

	void Start () {
		img = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myMode == GlobalData.gameMode) {
			img.enabled = true;
		} else
			img.enabled = false;
	}
}
