using UnityEngine;
using System.Collections;

public class GeneticVariance : MonoBehaviour {

	public GameObject animObj;
	float monster;

	void Start () {

		//randomize color
		Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		foreach(SpriteRenderer sr in animObj.GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		}

		// Monstrify
		if(Random.value > 0.95) {

			transform.localScale = new Vector3(transform.localScale.x * monster, transform.localScale.y * monster, 0 );
		}

		//randomize size
		var scalar = Random.Range(0.7f, 1.3f);
		transform.localScale = new Vector3(transform.localScale.x * scalar, transform.localScale.y * scalar, 0 );
	
	}

	void Update () {
	
	}
}
