using UnityEngine;
using System.Collections;

public class GeneticVariance : MonoBehaviour {

	public GameObject animObj;
	int monster;
	public int monsterLVL = 0;

	void Start () {

		//monster = WaveSpawn.globalWave;
		monster = 4;

		//randomize color
		Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		foreach(SpriteRenderer sr in animObj.GetComponentsInChildren<SpriteRenderer>()) {
			sr.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		}

		// Monstrify
		if(Random.value > 0.5) {
			monsterLVL = (int) monster;
			transform.localScale = new Vector3(transform.localScale.x * (monster+1), transform.localScale.y * (monster+1), 1 );
			transform.FindChild ("hurtbox").GetComponent<EnemyDamageScript> ().health *= (monster+1) * 10;
		}

		//randomize size
		var scalar = Random.Range(0.7f, 1.3f);
		transform.localScale = new Vector3(transform.localScale.x * scalar, transform.localScale.y * scalar, 1 );
	
	}

	void Update () {
	
	}
}
