using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public Transform target;
	public float smoothing;
	public bool cameraOff = false;

	Vector3 offset;
	// Use this for initialization
	void Start ()
	{
		offset = transform.position - target.position;
	}

	public void setCameraOn(bool up)
	{
		if (up == cameraOff) {
			return;
		}

		if (up == true) {
			// switch other cameras off
			// switch this one on
		} else {
			// switch this one off
			// switch others on
		}
	}

	void FixedUpdate ()
	{
		if (cameraOff == false) {
			Vector3 targetCamPos = target.position + offset;
			targetCamPos.y = this.transform.position.y;
			targetCamPos.z = this.transform.position.z;

			this.gameObject.transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}
}
