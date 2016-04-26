using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewMenuScript : MonoBehaviour {


	public void ChangeScene (string sceneName){
		StartCoroutine(DelayedSceneChange(sceneName, 0.7f));
		GameObject.FindGameObjectWithTag ("Screenfader").GetComponent<ScreenfaderScript> ().DropCurtains ();
	}


	// Allow for fade to black transitions
	IEnumerator DelayedSceneChange(string sceneName, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		SceneManager.LoadScene (sceneName);
	}

}