using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuController : MonoBehaviour {

	int active = 2;
	float secondsBreak = 9f;
	float cooldown;
	bool playersSwitched = false;
	Image switchOn, switchOff, goOn, goOff, exitOn, exitOff;
	Image red, blue;
	string firstScene = "main-scene";

	// Use this for initialization
	void Start () {
		switchOn = GameObject.FindGameObjectWithTag("switchActive").GetComponent<Image>();
		switchOff = GameObject.FindGameObjectWithTag("switchInactive").GetComponent<Image>();
		goOn = GameObject.FindGameObjectWithTag("goActive").GetComponent<Image>();
		goOff = GameObject.FindGameObjectWithTag("goInactive").GetComponent<Image>();
		exitOn = GameObject.FindGameObjectWithTag("exitActive").GetComponent<Image>();
		exitOff = GameObject.FindGameObjectWithTag("exitInactive").GetComponent<Image>();
		red = GameObject.FindGameObjectWithTag("Pl1").GetComponent<Image>();
		blue = GameObject.FindGameObjectWithTag("Pl2").GetComponent<Image>();

		switchOff.enabled = true;
		goOff.enabled = true;
		exitOff.enabled = true;

		allOff();
	}

	void allOff() {
		switchOn.enabled = false;
		goOn.enabled = false;
		exitOn.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		}

		if (cooldown <= 0) {
			if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("VerticalP1") > 0 || Input.GetAxis("VerticalP2") > 0) {
				active = (active + 1) % 3;
			} else if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("VerticalP1") < 0 || Input.GetAxis("VerticalP2") < 0) {
				active -= 1;
				if (active < 0) active = 2;
			} else if (Input.GetAxis("ButtonAP1") > 0 || Input.GetAxis("ButtonAP2") > 0) {
				if (active == 0) {
					#if UNITY_EDITOR
        			 UnityEditor.EditorApplication.isPlaying = false;
         			#elif UNITY_WEBPLAYER
					Application.OpenURL("http://nordicgamejam.org/");
         			#else
         			Application.Quit();
         			#endif
				} else if (active == 2) {
					GlobalData.PlayersSwitched = !GlobalData.PlayersSwitched;
					var position = blue.transform.position;

					blue.transform.position = red.transform.position;
					blue.transform.localScale = new Vector3(-1 * blue.transform.localScale.x, blue.transform.localScale.y, 1);

					red.transform.position = position;
					red.transform.localScale = new Vector3(-1 * red.transform.localScale.x, red.transform.localScale.y, 1);
				} else {
					Application.LoadLevel(firstScene);
				}
			}
			cooldown = secondsBreak * Time.deltaTime;
		}

		allOff();
		if (active == 0) {
			exitOn.enabled = true;	
		} else if (active == 1) {
			goOn.enabled = true;
		} else {
			switchOn.enabled = true;
		}
	}
}
