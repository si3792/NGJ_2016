using UnityEngine;
using System.Collections;

public class NuggetHandler : MonoBehaviour {

	public int nuggets = 200;
	public int NuggetsToWin;
	public float nuggetLeakRate = 7.0f;

	float timeToLeak = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if( this.tag == "the-ship" )
		{
			if (NuggetsToWin == nuggets) {
				gameObject.GetComponentInChildren<Spaceship> ().shipFueled ();
				Destroy (this);
			}
			if (timeToLeak < 0 ) {
				timeToLeak = nuggetLeakRate;
				nuggets--;
			}
			timeToLeak -= Time.deltaTime;
		}
	}
}
