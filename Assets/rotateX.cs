using UnityEngine;
using System.Collections;

public class rotateX : MonoBehaviour {

	public float speed;
	public float rotX = 0;
	public float rotY = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (speed * Time.deltaTime * rotX, speed * Time.deltaTime * rotY, 0));
	}
}
