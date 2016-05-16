using UnityEngine;
using System.Collections;

public class ControlTime : MonoBehaviour
{
	bool paused = false;
	bool isEditingTime = false;
    float timePauseStart, timePauseEnd, timeScaleBeforePause;
	public float editTimeReset;

	// Set time to newTimeScale for duration duration
	public void editTime (float newTimeScale, float duration)
	{

		if (isEditingTime == true)
			return;

		isEditingTime = true;
		editTimeReset = Time.realtimeSinceStartup + duration;
		Time.timeScale = newTimeScale;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}

	public void PauseUnpauseGame ()
	{
		if (paused) {
			Time.timeScale = timeScaleBeforePause;
			Time.fixedDeltaTime = 0.02F * timeScaleBeforePause;
			paused = false;

			//correct for pausing affecting editTime()
			timePauseEnd = Time.realtimeSinceStartup;
			editTimeReset += timePauseEnd - timePauseStart;

		} else {

			timeScaleBeforePause = Time.timeScale;
			timePauseStart = Time.realtimeSinceStartup;
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
			paused = true;

		}
	}

	void Update ()
	{
		// return to normal time
		if (!paused && isEditingTime && Time.realtimeSinceStartup > editTimeReset) {

			isEditingTime = false;
			Time.timeScale = 1f;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
		}

		// Pause/Unpause game
		if (Input.GetKeyDown (KeyCode.P)) {
			PauseUnpauseGame ();
		}

		//test slow time
		if (Input.GetKeyDown (KeyCode.L) && GlobalData.developerBuild) {
			editTime (0.2f, 5f);
		}
		else if (Input.GetKeyDown (KeyCode.J) && GlobalData.developerBuild) {
			editTime (0.4f, 5f);
		}

	}




}