using UnityEngine;
using System.Collections;

public class CameraTellerScript : MonoBehaviour {

	GameObject pl1, pl2;
	GameObject cam1, cam2;

	void Start () {
		pl1 = GameObject.FindGameObjectWithTag ("Pl1");
		pl2 = GameObject.FindGameObjectWithTag ("Pl2");

		cam1 = GameObject.FindGameObjectWithTag ("CameraP1");
		cam2 = GameObject.FindGameObjectWithTag ("CameraP2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getCameraForPlayer(bool playerOne) {

		Vector3 dist = pl1.transform.position - pl2.transform.position;
		if (dist.x < 0) 
			return (playerOne)? cam1 : cam2;
		return (playerOne)? cam2 : cam1;

	}


}
