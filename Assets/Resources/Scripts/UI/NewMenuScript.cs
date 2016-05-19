using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewMenuScript : MonoBehaviour {


	public void ChangeScene (string sceneName){
		StartCoroutine(DelayedSceneChange(sceneName, 0.20f));
		GameObject.FindGameObjectWithTag ("Screenfader").GetComponent<ScreenfaderScript> ().DropCurtains ();
	}


	// Allow for fade to black transitions
	IEnumerator DelayedSceneChange(string sceneName, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		SceneManager.LoadScene (sceneName);
	}

	public void toggleSound(bool turnOn) {
		GlobalData.soundFXOn = turnOn;
		GlobalData.musicOn = turnOn;
	}

	public void quitGame() {
		Application.Quit ();
	}


	public void changeGameMode(int mode) {
		if (mode >= 0 && mode < 3)
			GlobalData.gameMode = mode;

		// + and - Mode
		if (mode == 10)
			GlobalData.gameMode = Mathf.Min (GlobalData.gameMode + 1, 2);
		else if (mode == -10) {
			GlobalData.gameMode = Mathf.Max (GlobalData.gameMode - 1, 0);
		}


	}


}