using UnityEngine;
using System.Collections;
using System;

public class CameraSupervisor : MonoBehaviour {

	public float scaleRatio = 0.6f;
	public float scaleDownRatio = 0.55f;
	public float splitAtCamScale = 1.5f;
	public float defaultCamSize = 4f;

	Transform pl1;
	Transform pl2;
	GameObject camMain;
	GameObject camP1;
	GameObject camP2;
	CrossControl crossMain;
	CrossControl crossP1;
	CrossControl crossP2;

	bool split = false;
	bool scale = false;
	float camStartY;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("Pl1") != null) {
			pl1 = GameObject.FindGameObjectWithTag ("Pl1").transform;
		}
		if(GameObject.FindGameObjectWithTag("Pl2") != null) {
			pl2 = GameObject.FindGameObjectWithTag ("Pl2").transform;
		}
		if(GameObject.FindGameObjectWithTag("MainCamera") != null) {
			camMain = GameObject.FindGameObjectWithTag ("MainCamera");
		}
		if(GameObject.FindGameObjectWithTag("CameraP1") != null) {
			camP1 = GameObject.FindGameObjectWithTag ("CameraP1");
		}
		if(GameObject.FindGameObjectWithTag("CameraP2") != null) {
			camP2 = GameObject.FindGameObjectWithTag ("CameraP2");
		}
		if(GameObject.FindGameObjectWithTag("CrossMain") != null) {
			crossMain = GameObject.FindGameObjectWithTag ("CrossMain").GetComponent<CrossControl>();
		}
		if(GameObject.FindGameObjectWithTag("CrossP1") != null) {
			crossP1 = GameObject.FindGameObjectWithTag ("CrossP1").GetComponent<CrossControl>();
		}
		if(GameObject.FindGameObjectWithTag("CrossP2") != null) {
			crossP2 = GameObject.FindGameObjectWithTag ("CrossP2").GetComponent<CrossControl>();
		}

		camMain.GetComponent<Camera>().enabled = true;
		camP1.GetComponent<Camera>().enabled = false;
		camP2.GetComponent<Camera>().enabled = false;
		camMain.GetComponent<Camera>().orthographicSize = defaultCamSize;
		camP1.GetComponent<Camera>().orthographicSize = defaultCamSize;
		camP2.GetComponent<Camera>().orthographicSize = defaultCamSize;
		crossMain.curMode = modes.FollowBoth;
		crossP1.curMode = modes.FollowBoth;
		crossP2.curMode = modes.FollowBoth;
		camStartY = camMain.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		var distance = Vector3.Distance(pl1.position, pl2.position);
		if (split == false) {
			var cam = camMain.GetComponent<Camera>();
			float origWidth = 2f * defaultCamSize * cam.aspect;
			float height = 2f * cam.orthographicSize;
 			float width = height * cam.aspect;

			if (distance / origWidth < scaleDownRatio) {
				if (scale == true) {
					// Reset view
					cam.orthographicSize = 4f;
					Vector3 newPosition = camMain.transform.position;
					newPosition.y = camStartY;
					cam.transform.position = newPosition;
					scale = false;
				}
			} else if (cam.orthographicSize < defaultCamSize * splitAtCamScale) {
				if ((distance / origWidth) >= scaleRatio) {
					scale = true;
					cam.orthographicSize = Math.Max(defaultCamSize, distance / (1.6f * cam.aspect));
					Vector3 newPosition = camMain.transform.position;
					newPosition.y = camStartY + (cam.orthographicSize - defaultCamSize);
					cam.transform.position = newPosition;
				} 
			} else {
				Debug.Log("Time to split!!!");
			}
		}
	}
}
