using UnityEngine;
using System.Collections;

public class growInSize : MonoBehaviour {

	public float currentScale;
	public float maxScale;
	public float maxScalePlus;
	public float step = 0.01f;
	public bool pulse = false;
	bool increasePulse = true;

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(currentScale < maxScale) {
			currentScale += step;

		} else if(pulse)
		{
			if(increasePulse) {
				currentScale += step;
				if (maxScalePlus <= currentScale)
					increasePulse = false;
			} else {
				currentScale -= step;
				if (maxScale > currentScale)
					increasePulse = true;
			}


		}


		transform.localScale = new Vector3 (currentScale, currentScale, 0);	
	}
}
