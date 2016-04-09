using UnityEngine;
using System.Collections;
using System;

public class CameraSupervisor : MonoBehaviour {

	public float scaleRatio = 0.6f;
	public float scaleDownRatio = 0.55f;
	public float splitAtCamScale = 1.5f;
	public float defaultCamSize = 60f;
	public float secondsToZoomBack = 1.5f;
	public float restSeconds = 0.2f;

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
	float stepDifference;
	int restSteps;

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
		var cam = camMain.GetComponent<Camera>();
		float origWidth = 2f * defaultCamSize * cam.aspect;
		float height = 2f * cam.orthographicSize;
 		float width = height * cam.aspect;

		if (split == false) {

			if (pl1.position.x < pl2.position.x) {
				crossP1.curMode = modes.FollowPl1;
				crossP2.curMode = modes.FollowPl2;
			} else {
				crossP1.curMode = modes.FollowPl2;
				crossP2.curMode = modes.FollowPl1;
			}

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
				if ((distance / width) >= scaleRatio) {
					cam.orthographicSize = Math.Max(defaultCamSize, distance / (2f * scaleRatio * cam.aspect));
				} else if ((distance / width) <= scaleDownRatio) {
					cam.orthographicSize = Math.Max(defaultCamSize, distance / (2f * scaleDownRatio * cam.aspect));
				}
				scale = true;
				Vector3 newPosition = camMain.transform.position;
				newPosition.y = camStartY + (cam.orthographicSize - defaultCamSize);
				cam.transform.position = newPosition;
			} else {
				split = true;
				var cl = camP1.GetComponent<Camera>();
				var cr = camP2.GetComponent<Camera>();
				cam.enabled = false;
				cl.GetComponent<Camera>().enabled = true;
				cr.GetComponent<Camera>().enabled = true;
				cl.orthographicSize = cam.orthographicSize;
				cr.orthographicSize = cam.orthographicSize;
				var pos = cl.transform.position;
				pos.y = cam.transform.position.y;
				cl.transform.position = pos;
				pos = cr.transform.position;
				pos.y = cam.transform.position.y;
				cr.transform.position = pos;

				stepDifference = (cl.orthographicSize - defaultCamSize) / secondsToZoomBack;
				restSteps = (int) (restSeconds / Time.deltaTime);
			}
		} else {
			var cl = camP1.GetComponent<Camera>();
			var cr = camP2.GetComponent<Camera>();
			if (distance <= origWidth / 2) {
				cam.enabled = true;
				cl.enabled = false;
				cr.enabled = false;
				cam.orthographicSize = defaultCamSize;
				Vector3 newPosition = cam.transform.position;
				newPosition.y = camStartY + (cam.orthographicSize - defaultCamSize);
				cam.transform.position = newPosition;
				split = false;
			} else if (cl.orthographicSize > defaultCamSize) {
				if (restSteps > 0) {
					restSteps--;
					return;
				}
				cl.orthographicSize -= stepDifference * Time.deltaTime;
				cr.orthographicSize -= stepDifference * Time.deltaTime;
				cl.orthographicSize = Math.Max(cl.orthographicSize, defaultCamSize);
				cr.orthographicSize = Math.Max(cr.orthographicSize, defaultCamSize);
				Vector3 newPosition = cl.transform.position;
				newPosition.y = camStartY + (cl.orthographicSize - defaultCamSize);
				cl.transform.position = newPosition;
				newPosition = cr.transform.position;
				newPosition.y = camStartY + (cr.orthographicSize - defaultCamSize);
				cr.transform.position = newPosition;

			}
		}
	}
}
