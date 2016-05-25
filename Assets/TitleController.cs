using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

	public GameObject liftoff, death, fame;

	void Start () {
		if(GlobalData.gameMode == 2) {
			fame.GetComponent<Image>().enabled = true;
			return;
		}


		if (GlobalData.p1survived || GlobalData.p2survived){
			liftoff.GetComponent<Image> ().enabled = true;
			return;
		}

		death.GetComponent<Image> ().enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
