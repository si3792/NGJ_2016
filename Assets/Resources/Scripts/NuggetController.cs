using UnityEngine;
using System.Collections;

public class NuggetController : MonoBehaviour {


	GameObject Pl1, Pl2;
	float dist1, dist2, dist;
	Transform target;
	float threshold= 2;
	float smoothing = 0.5f	;

	float getSmoothing(float dist) {
		return threshold / dist;
	}

	// Use this for initialization
	void Start () {
		Pl1 = GameObject.FindGameObjectWithTag ("Pl1");
		Pl2 = GameObject.FindGameObjectWithTag ("Pl2");
	}
		
	// Update is called once per frame
	void Update () {

		dist1 = Vector3.Distance (transform.position, Pl1.transform.position);
		dist2 = Vector3.Distance (transform.position, Pl2.transform.position);
		if (dist1 > dist2) {
			target = Pl2.transform;
			dist = dist2;
		} else {
			target = Pl1.transform;
			dist = dist1;
		}

		if(dist < threshold) {
			transform.position = Vector3.Lerp (transform.position, target.position, getSmoothing(dist) * Time.deltaTime);
		}

		
	}


	void OnTriggerEnter2D(Collider2D other) {

		if(other.tag == "pl-hurtbox") {
			Destroy (this.gameObject);
			//TODo - effect and add score
		}

	}

}
