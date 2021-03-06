﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading;

public enum CameraId {
	main = 0,
	left,
	right,
	ui
}

public class PerspectiveCameraSupervisor : MonoBehaviour {

	public float scaleRatio = 0.6f;
	public float scaleDownRatio = 0.55f;
	public float splitAtCamScale = 1.5f;
	public float secondsToZoomBack = 1.5f;
	public float restSeconds = 0.2f;
	public float zoomOutOfDeadDelay = 2f;

	Transform pl1;
	Transform pl2;
	GameObject camMain;
	GameObject camP1;
	GameObject camP2;
	CrossControl crossMain;
	CrossControl crossP1;
	CrossControl crossP2;

	bool singlePlayer = false;
	bool split = false;
	bool scale = false;
	bool zoomInSplit = false;
	float camStartY;
	float stepDifference;
	float camOrigHeight;
	float origWidth;
	float camBaseZ;
	int restSteps;
	//private Mutex callbackMutex = new Mutex();
	public delegate void DelayedExecution();
	protected LinkedList<KeyValuePair<float, DelayedExecution>> callbacks = new LinkedList<KeyValuePair<float, DelayedExecution>>();

	public void FocusCameraOnPoint(Vector3 center, float time = 1f, CameraId camId = CameraId.main, float height = 0) {
		if (height == 0) {
			height = camOrigHeight;
		}
		Camera camObj = camMain.GetComponent<Camera>();
		CrossControl focalPoint = crossMain;
		switch (camId) {
			case CameraId.main:
				camObj = camMain.GetComponent<Camera>();
				focalPoint = crossMain;
				break;
			case CameraId.left:
				camObj = camP1.GetComponent<Camera>();
				if (pl1.position.x < pl2.position.x) {
					focalPoint = crossP1;
				} else {
					focalPoint = crossP2;
				}
				break;
			case CameraId.right:
				camObj = camP2.GetComponent<Camera>();
				if (pl1.position.x < pl2.position.x) {
					focalPoint = crossP2;
				} else {
					focalPoint = crossP1;
				}
				break;
			default:
				Debug.Log("Unrecognized CameraId in CameraSupervisor.FocusCameraOnPoint");
				break;
		}
		focalPoint.ForceFocus(center);

		var oldPos = camObj.transform.position;
		center.z = -(height * 0.5f / Mathf.Tan(camObj.fieldOfView * 0.5f * Mathf.Deg2Rad));
		camMain.transform.position = center;
		addDelayedExecution(time, new DelayedExecution( 
			() => { 
				camObj.transform.position = new Vector3(camObj.transform.position.x, camObj.transform.position.y, oldPos.z);
				focalPoint.ForceFocus(null);
			}));
	}

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
		crossMain.curMode = modes.FollowBoth;
		crossP1.curMode = modes.FollowBoth;
		crossP2.curMode = modes.FollowBoth;
		camOrigHeight = 2.0f * Math.Abs(camMain.transform.position.z) * Mathf.Tan(camMain.GetComponent<Camera>().fieldOfView * 0.5f * Mathf.Deg2Rad);
		origWidth = camOrigHeight * camMain.GetComponent<Camera>().aspect;
		camStartY = camMain.transform.position.y;
		camBaseZ = camMain.transform.position.z;


		//FocusCameraOnPoint(new Vector3(-22f, -2.5f, 0f), 2);
	}

	void addDelayedExecution(float t, DelayedExecution callback) {
		//callbackMutex.WaitOne();
		callbacks.AddLast(new KeyValuePair<float, DelayedExecution>(t, callback));
		//callbackMutex.ReleaseMutex();
	}

	void checkDelayedExecution() {
		var remaining = new LinkedList<KeyValuePair<float, DelayedExecution>>();
		//callbackMutex.WaitOne();
		foreach (var pair in callbacks) {
			var newP = new KeyValuePair<float, DelayedExecution>(pair.Key - Time.deltaTime, pair.Value);
			if (newP.Key <= 0) {
				newP.Value();
			} else {
				remaining.AddLast(newP);
			}
		}
		callbacks = remaining;
		//callbackMutex.ReleaseMutex();
	}

	// Update is called once per frame
	void Update () {
		checkDelayedExecution();

		var cam = camMain.GetComponent<Camera>();

		if (pl1 == null || pl2 == null && singlePlayer == false) {
			// Someone just died
			singlePlayer = true;
			if (pl1 == null) {
				crossMain.curMode = modes.FollowPl2;
			} else {
				crossMain.curMode = modes.FollowPl1;
			}
			if (cam.enabled == false) {
				var cl = camP1.GetComponent<Camera>();
				var cr = camP2.GetComponent<Camera>();
				addDelayedExecution(zoomOutOfDeadDelay, new DelayedExecution( 
					() => {
						cam.enabled = true;
						cl.enabled = false;
						cr.enabled = false;
						Vector3 newPosition = cam.transform.position;
						newPosition.z = cl.transform.position.z;
						var height = 2.0f * Math.Abs(newPosition.z) * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
						newPosition.y = camStartY + ((height - camOrigHeight) / 2);
						cam.transform.position = newPosition;
						split = false;
				}));
			}
		}

		if (!singlePlayer) {
			var distance = Vector3.Distance(pl1.position, pl2.position);
			float height = 2.0f * Math.Abs(cam.transform.position.z) * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
	 		float width = height * cam.aspect;

			if (pl1.position.x < pl2.position.x) {
				crossP1.curMode = modes.FollowPl1;
				crossP2.curMode = modes.FollowPl2;
			} else {
				crossP1.curMode = modes.FollowPl2;
				crossP2.curMode = modes.FollowPl1;
			}

			if (split == false) {
				if (distance / origWidth < scaleDownRatio) {
					if (scale == true) {
						// Reset view
						//Vector3 newPosition = camMain.transform.position;
						//newPosition.y = camStartY;
						//newPosition.z = camBaseZ;
						//cam.transform.position = newPosition;
						scale = false;
					}
				} else if (Math.Abs(cam.transform.position.z) < Math.Abs(camBaseZ) * splitAtCamScale) {
					Vector3 newPosition = camMain.transform.position;
					if ((distance / width) >= scaleRatio) {
						newPosition.z = Math.Min(newPosition.z, -(distance / (scaleRatio * cam.aspect * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad) * 2.0f)));
					} else if ((distance / width) <= scaleDownRatio) {
						newPosition.z = Math.Max(newPosition.z, -(distance / (scaleDownRatio * cam.aspect * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad) * 2.0f)));
					}
					scale = true;
					height = 2.0f * Math.Abs(cam.transform.position.z) * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
					newPosition.y = camStartY + ((height - camOrigHeight) / 2);
					cam.transform.position = newPosition;
				} else {
					split = true;
					var cl = camP1.GetComponent<Camera>();
					var cr = camP2.GetComponent<Camera>();
					cam.enabled = false;
					cl.GetComponent<Camera>().enabled = true;
					cr.GetComponent<Camera>().enabled = true;
					var pos = cl.transform.position;
					pos.y = cam.transform.position.y;
					pos.z = cam.transform.position.z;
					cl.transform.position = pos;
					pos.x = cr.transform.position.x;
					cr.transform.position = pos;

					stepDifference = Math.Abs(cam.transform.position.z - camBaseZ) / secondsToZoomBack;
					addDelayedExecution(restSeconds, new DelayedExecution( () => { zoomInSplit = true; }));
					//zoomInSplit = true;
					restSteps = (int) (restSeconds / Time.deltaTime);
				}
			} else {
				var cl = camP1.GetComponent<Camera>();
				var cr = camP2.GetComponent<Camera>();
				var halfHeight = 2.0f * Math.Abs(cl.transform.position.z) * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
				var halfWidth = halfHeight * cl.aspect;
				if (distance < halfWidth) {
					// Merge cameras
					cam.enabled = true;
					cl.enabled = false;
					cr.enabled = false;
					Vector3 newPosition = cam.transform.position;
					newPosition.z = cl.transform.position.z;
					height = 2.0f * Math.Abs(newPosition.z) * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
					newPosition.y = camStartY + ((height - camOrigHeight) / 2);
					cam.transform.position = newPosition;
					split = false;
				} else if (cl.transform.position.z < camBaseZ) {
					if (restSteps > 0) {
						restSteps--;
						return;
					}
					Vector3 newPosition = cl.transform.position;
					newPosition.z = newPosition.z + stepDifference * Time.deltaTime;
					height = 2.0f * Math.Abs(newPosition.z) * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
					newPosition.y = camStartY + ((height - camOrigHeight) / 2);
					cl.transform.position = newPosition;
					newPosition.x = cr.transform.position.x;
					cr.transform.position = newPosition;

				}
			}
		}
	}
}
