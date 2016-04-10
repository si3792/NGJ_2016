using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NuggetsDisplayScript : MonoBehaviour {

	NuggetHandler nuggetController;
	Image left, right;


	// Use this for initialization
	void Start () {
		nuggetController = GameObject.FindGameObjectWithTag("the-ship").GetComponent<NuggetHandler>();
		left = GameObject.FindGameObjectWithTag("hp-bar-mid-l").GetComponent<Image>();
		right = GameObject.FindGameObjectWithTag("hp-bar-mid-r").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		float fill = 0.03f + 0.97f * ((float) nuggetController.nuggets / (float) nuggetController.NuggetsToWin);
		left.fillAmount = fill;
		right.fillAmount = fill;
	}
}
