using UnityEngine;
using System.Collections;

public class NuggetAtractor : MonoBehaviour {

	GameObject ship;
	// Use this for initialization
	float threshold= 4;

	float getSmoothing(float dist) {
		return threshold / dist;
	}

	void Start () {
		ship = GameObject.FindGameObjectWithTag ("the-ship");
	}

	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance (transform.position, ship.transform.position);
		if (dist < 0.1f) {
			GameObject.Destroy (gameObject);
			return;
		}
		transform.position = Vector3.Lerp (transform.position, ship.transform.position, getSmoothing(dist) * Time.deltaTime);

	}
}
