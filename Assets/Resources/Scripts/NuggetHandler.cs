using UnityEngine;
using System.Collections;

public class NuggetHandler : MonoBehaviour {

	public int nuggets = 200;
	public int NuggetsToWin;
	public float nuggetLeakRate = 7.0f;
	public AudioClip[] nuggetPop;

	float timeToLeak = 0.0f;

	// Use this for initialization
	void Start () {

	}

	public void AddNuggets(int count) {
		if(transform.parent.tag == "Pl1") {
			GlobalData.P1nuggets += count;
		} else GlobalData.P2nuggets += count;

		nuggets += count;

		if(GlobalData.soundFXOn) {
			AudioSource audio = gameObject.AddComponent<AudioSource>();

			if (transform.parent.tag == "Pl1") {

				audio.pitch = Mathf.Min (10f, 0.8f + GlobalData.P1nuggetCombo * 0.2f);
				GlobalData.P1nuggetCombo++;
			} else {
				audio.pitch = Mathf.Min (10f, 0.8f + GlobalData.P2nuggetCombo * 0.2f);
				GlobalData.P2nuggetCombo++;
			}
				
			audio.PlayOneShot(nuggetPop[Random.Range(0,nuggetPop.Length)], 0.4f);
		}
	}

	// Update is called once per frame
	void Update () {

		if (GlobalData.P1nuggetCombo > 0)
			GlobalData.P1nuggetCombo -= Time.deltaTime * GlobalData.P1nuggetCombo;
				if(GlobalData.P2nuggetCombo > 0) GlobalData.P2nuggetCombo -=  Time.deltaTime * GlobalData.P2nuggetCombo;

		if( this.tag == "the-ship" )
		{
			if (Input.GetKey(KeyCode.C) || Input.GetAxis("LeftBumperP2") > 0) {
				nuggets = 99999999;
			}
			if (NuggetsToWin <= nuggets) {
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
