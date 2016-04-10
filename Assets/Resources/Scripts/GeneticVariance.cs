using UnityEngine;
using System.Collections;

public class GeneticVariance : MonoBehaviour {

	public GameObject animObj;
	int monster = 1;
	public int monsterLVL = 1;

	void Start () {

		//monster = WaveSpawn.globalWave;
		monster = 0;

		//randomize color
		Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		foreach(SpriteRenderer sr in animObj.GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		}

		//randomize size
		var scalar = Random.Range(0.7f, 1.3f);
		transform.localScale = new Vector3(transform.localScale.x * scalar, transform.localScale.y * scalar, 1 );
	
	}

	void Update () {
	
	}
}
