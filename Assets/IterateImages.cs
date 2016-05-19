using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IterateImages : MonoBehaviour {

	// Iterates images, with delay on end (could be random from range)
	public Sprite[] spr;
	public float changeTime;
	public bool endDelay;
	public float delayMin;
	public float delayMax;

	Image img;
	bool delayedFlag = false;
	int cur = 0;
 
	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();
		InvokeRepeating ("next", 0f, changeTime);
	}

	void next(){

		if (delayedFlag)
			return;

		img.sprite = spr [cur];
		cur++;

		if(cur >= spr.Length) {
			cur = 0;
			delayedFlag = true;
			Invoke ("stopDelay", Random.Range(delayMin, delayMax));
		}
	}

	void stopDelay(){
		delayedFlag = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
