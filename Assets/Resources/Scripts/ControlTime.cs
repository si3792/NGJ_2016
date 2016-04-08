﻿using UnityEngine;
using System.Collections;

public class ControlTime : MonoBehaviour {

	public bool paused = false;
	public float scalar = 1;
	public bool changeTime = true;



	// Update is called once per frame
	void Update () {

		// Change time scale
		if(changeTime) {
			changeTime = false;

			Time.timeScale = scalar;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
		}

		// Pause/Unpause game
		if(Input.GetKeyDown(KeyCode.P)) {
			if(paused) {
				Time.timeScale = 1;
				Time.fixedDeltaTime = 0.02F;
				paused = false;
			} else {
				Time.timeScale = 0;
				Time.fixedDeltaTime = 0;
				paused = true;
			}

		}

	}
}