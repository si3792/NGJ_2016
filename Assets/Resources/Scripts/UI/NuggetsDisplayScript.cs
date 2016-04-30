using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NuggetsDisplayScript : MonoBehaviour {

	NuggetHandler nuggetController;
	Image bar;


	// Use this for initialization
	void Start () {
		nuggetController = GameObject.FindGameObjectWithTag("the-ship").GetComponent<NuggetHandler>();
		bar =gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		float fill = 0.03f + 0.97f * ((float) nuggetController.nuggets / (float) nuggetController.NuggetsToWin);
		bar.fillAmount = fill;
	}
}
