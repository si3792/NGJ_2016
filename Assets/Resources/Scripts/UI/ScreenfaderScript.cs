using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenfaderScript : MonoBehaviour {

	public float fadeSpeedIn = 5f; 
	public float fadeSpeedOut = 5f;
	public bool transitionIntself = false;
	public string scene;

	public bool sceneStarting = true, sceneEnding = false;
	Image img;

	void Start () {
		img = GetComponent<Image> ();
		img.enabled = true;
	}

	void Update() {
		if (sceneStarting)
			Invoke ("StartingScene", 0.2f);

		if (sceneEnding)
			Invoke ("FadeToBlack", 0f);
	}

	void changeScene() {
		Application.LoadLevel(scene);
	}

	void FadeToBlack() {
		Color tmp = Color.Lerp (img.color, Color.black, fadeSpeedOut * Time.deltaTime);
		img.color = tmp;

		if(transitionIntself && tmp == Color.black) {
			changeScene ();
		}
	}

	void FadeToClear() {
		Color tmp = Color.Lerp (img.color, Color.clear, fadeSpeedIn * Time.deltaTime);
		img.color = tmp;
	}


	void StartingScene () {
		FadeToClear ();

		if(img.color.a < 0.05f) {
			img.color = Color.clear;
			sceneStarting = false;
		}

	}


	public void DropCurtains() {
		sceneEnding = true;
	}

}
