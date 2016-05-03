using UnityEngine;
using System.Collections;

public class RimController : MonoBehaviour {

	public float chanceToSurge;
	void Start () {
		

	}
	

	void Update () {

		foreach(GameObject rim in GameObject.FindGameObjectsWithTag("Rim")) {
			if (rim.GetComponent<RimScript> ().surging)
				continue;

			if(Random.value > (1-chanceToSurge)){
				rim.GetComponent<RimScript> ().surging = true;
				rim.GetComponent<Animator> ().SetTrigger ("surge");
			}

		}

	}
}
