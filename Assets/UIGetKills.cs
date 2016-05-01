using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGetKills : MonoBehaviour {

	public bool playerOne;
	Text text;

	void Start () {
		text = GetComponent<Text> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if(playerOne)
			text.text = GlobalData.P1kills.ToString();
		else
			text.text = GlobalData.P2kills.ToString();
	}
}
