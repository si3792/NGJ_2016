﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountController : MonoBehaviour {

	public AudioClip nuggetFX, killFX, finalFX, transitionFX;
	public GameObject P1nuggs, P2nuggs;
	public GameObject P1kills, P2kills;
	public float startStep = 0.3f;
	public float minStep = 0.1f;
	public float scaler = 1f;
	public float initialVolume, finalVolume;
	float curStep;
	public float startSpeed, maxSpeed;
	public float startPitch, maxPitch;
	float plusCountMin, plusCountMax;
	public float plusCountScaler = 60f;
	float p1n = 0, p2n = 0;
	float p1k = 0, p2k = 0;
	bool doneFlag = false;
	bool added = true;
	float progress = 1;
	AudioSource myAS;
	int mode = 1; // 1 - add nuggets, 2 - add kills 3 - drop final score

	void Start () {
		curStep = startStep;
		myAS = GetComponent<AudioSource> ();

		plusCountMin = Mathf.Max (GlobalData.P1nuggets, GlobalData.P2nuggets) / plusCountScaler;
		plusCountMax = 3 + plusCountMin;
	}

	void AddNuggets() {

		p1n += Random.Range(plusCountMin, plusCountMax);
		p2n += Random.Range(plusCountMin, plusCountMax);


		if (p1n > GlobalData.P1nuggets)
			p1n = GlobalData.P1nuggets;
		else
			P1nuggs.GetComponent<popText> ().Pop ();

		if (p2n > GlobalData.P2nuggets)
			p2n = GlobalData.P2nuggets;
		else
			P2nuggs.GetComponent<popText> ().Pop ();

		if (p1n == GlobalData.P1nuggets && p2n == GlobalData.P2nuggets) {
			mode = 2;
			progress = 1;
			plusCountMin = Mathf.Max (GlobalData.P1kills, GlobalData.P2kills) / plusCountScaler;
			plusCountMax = 3 + plusCountMin;
			myAS.PlayOneShot (transitionFX);
			myAS.volume = initialVolume;

			if(GlobalData.P1nuggets > GlobalData.P2nuggets) {
				P1nuggs.GetComponent<popText> ().popAmount = 3f;
				P1nuggs.GetComponent<popText> ().Pop (); 
			} else { 
				P2nuggs.GetComponent<popText> ().popAmount = 3f;
				P2nuggs.GetComponent<popText> ().Pop (); 
			}

		} else {
			myAS.PlayOneShot (nuggetFX);
		}

	
		P1nuggs.GetComponent<Text> ().text = ((int)p1n).ToString();
		P2nuggs.GetComponent<Text> ().text = ((int)p2n).ToString();
		added = true;
	}


	void AddKills() {

		p1k += Random.Range(plusCountMin, plusCountMax);
		p2k += Random.Range(plusCountMin, plusCountMax);


		if (p1k > GlobalData.P1kills)
			p1k = GlobalData.P1kills;
		else
			P1kills.GetComponent<popText> ().Pop ();

		if (p2k > GlobalData.P2kills)
			p2k = GlobalData.P2kills;
		else
			P2kills.GetComponent<popText> ().Pop ();

		if (p1k == GlobalData.P1kills && p2k == GlobalData.P2kills) {
			mode = 3;
			myAS.PlayOneShot (transitionFX);
			if(GlobalData.P1kills > GlobalData.P2kills) {
				P1kills.GetComponent<popText> ().popAmount = 3f;
				P1kills.GetComponent<popText> ().Pop (); 
			} else { 
				P2kills.GetComponent<popText> ().popAmount = 3f;
				P2kills.GetComponent<popText> ().Pop (); 
			}

		} else {
			myAS.PlayOneShot (killFX);
		}


		P1kills.GetComponent<Text> ().text = ((int)p1k).ToString();
		P2kills.GetComponent<Text> ().text = ((int)p2k).ToString();
		added = true;
	}

	float getT() {
		return progress / (progress + scaler);
	}

	void drop_final(){
		myAS.pitch = 1f;
		myAS.PlayOneShot (finalFX);
		GetComponent<Animator> ().SetTrigger ("drop_final");

	}

	void Update () {
	
		if(mode == 1)
		if(added == true) {
			added = false;
			curStep = Mathf.Lerp (startStep, minStep, getT());
			Invoke ("AddNuggets", curStep);
			P1nuggs.GetComponent<popText> ().popSpeed = Mathf.Lerp (startSpeed, maxSpeed, getT());
			P2nuggs.GetComponent<popText> ().popSpeed = Mathf.Lerp (startSpeed, maxSpeed, getT());
			myAS.pitch =  Mathf.Lerp (startPitch, maxPitch, getT());
			myAS.volume =  Mathf.Lerp (initialVolume, finalVolume, getT());

			progress++;
		}

		if(mode == 2) {
			if(added == true) {
				added = false;
				curStep = Mathf.Lerp (startStep, minStep, getT());
				Invoke ("AddKills", curStep);
				P1kills.GetComponent<popText> ().popSpeed = Mathf.Lerp (startSpeed, maxSpeed, getT());
				P2kills.GetComponent<popText> ().popSpeed = Mathf.Lerp (startSpeed, maxSpeed, getT());
				myAS.pitch =  Mathf.Lerp (startPitch, maxPitch, getT());

				progress++;
			}
		}

		if(mode == 3) {
			mode = 4;
			Invoke ("drop_final", 0.3f);
		}


	}
}
