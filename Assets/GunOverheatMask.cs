using UnityEngine;
using System.Collections;

public class GunOverheatMask : MonoBehaviour {

	public float blinkTimeout = 1f;
	public float blinkSpeed = 2000f;

	private int mode = 1; // 0 - off, 1 - percentage of overheat, 2 - blink
	private bool increasingBlink = true;
	private bool blinkTimeoutFlag = false;
	private SpriteRenderer mySR;

	void Start () {
		mySR = GetComponent<SpriteRenderer> ();
	}

	void resetBlinkTimeout() {
		blinkTimeoutFlag = false;
	}

	void Update () {

		if (GlobalData.overheatLock)
			mode = 2;
		else
			mode = 1;

		if (mode == 0)
			mySR.color = new Color (0f, 0f, 0f, 0f);

		if(mode == 1) {
			mySR.color = new Color(1f, 1f, 1f, GlobalData.overheatPercent/100f);
		}

		if(mode == 2) {

			if (blinkTimeoutFlag)
				return;

			if(increasingBlink)
				mySR.color = new Color (1f, 1f, 1f, Mathf.Lerp (0f, 1f, blinkSpeed * Time.deltaTime));	
			else 
				mySR.color = new Color (1f, 1f, 1f, Mathf.Lerp (1f, 0f, blinkSpeed * Time.deltaTime));	
		
		
			if (mySR.color.a == 1f){
				increasingBlink = false;
				blinkTimeoutFlag = true;
				Invoke ("resetBlinkTimeout", blinkTimeout);
			}
				
			if (mySR.color.a == 0f) {
				increasingBlink = true;
				blinkTimeoutFlag = true;
				Invoke ("resetBlinkTimeout", blinkTimeout);
			}
		}	
	}


	public void setMode(int x) {
		mode = x;
	}

}
