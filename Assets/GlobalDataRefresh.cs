using UnityEngine;
using System.Collections;

public class GlobalDataRefresh : MonoBehaviour {


	void Start () {

		// Reset stuff for new game
		//GlobalData.
		GlobalData.P1kills = 0;
		GlobalData.P2kills = 0;
		GlobalData.P1nuggets = 0;
		GlobalData.P2nuggets = 0;
		GlobalData.p1survived = false;
		GlobalData.p2survived = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
