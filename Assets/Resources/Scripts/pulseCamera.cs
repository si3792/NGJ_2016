using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class pulseCamera : MonoBehaviour {

	VignetteAndChromaticAberration fx;
	public float maxPulse, minPulse, deltaPulse;


	public bool pulsing;
	float timeLeft;
	public void MakeMePulse(float duration) {

		if (pulsing) {
			return;	
		}
		timeLeft = duration;
		pulsing = true;
	}

	public void StopPulse() {
		pulsing = false;
	}

	float curPulse;

	void Start () {
		fx = GetComponent<VignetteAndChromaticAberration> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pulsing) {
			pulse ();
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0)
				pulsing = false;
		}
		else {
			if(fx.chromaticAberration != 0 || fx.intensity != 0)
			unpulse ();
		}


	}

	void unpulse () {


		fx.chromaticAberration = 0;
	
		fx.intensity = 0;
	}


	void pulse() {
		if (Time.timeScale < 0.05f)
			return; // dont pulse on pause
		
		curPulse += deltaPulse * Time.deltaTime;
		if (curPulse > maxPulse || curPulse < minPulse) {
			deltaPulse *= -1;
			curPulse += 2 * deltaPulse * Time.deltaTime;
		}

		fx.chromaticAberration = curPulse;
		fx.intensity = Mathf.Clamp(Mathf.Abs (curPulse) / maxPulse, 0.01f, 0.4f );
	}


}
