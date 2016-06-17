using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayHighscore : MonoBehaviour {

	public int substring = 0;
	private GameObject hsController;

	void Start () {
		hsController = GameObject.FindGameObjectWithTag ("HSController");
		GetComponent<Text> ().text = "Loading...";
	}
	
	// Update is called once per frame
	void Update () {

		if(hsController.GetComponent<HSController> ().displayHighscore.Length > substring)
		GetComponent<Text> ().text = hsController.GetComponent<HSController> ().displayHighscore [substring];
	}
}
