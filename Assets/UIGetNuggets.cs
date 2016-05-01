using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGetNuggets : MonoBehaviour {

	public bool playerOne;
	Text text;

	void Start () {
		text = GetComponent<Text> ();	
	}

	// Update is called once per frame
	void Update () {
		if(playerOne)
			text.text = GlobalData.P1nuggets.ToString();
		else
			text.text = GlobalData.P2nuggets.ToString();
	}
}
