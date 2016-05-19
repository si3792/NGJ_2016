using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finalScoreScript : MonoBehaviour {

	Text txt;
	public int finalScore;

	void Start () {
		txt = GetComponent<Text> ();	
		finalScore = GlobalData.P1kills + GlobalData.P2kills + GlobalData.P1nuggets + GlobalData.P2nuggets;
		txt.text = finalScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
