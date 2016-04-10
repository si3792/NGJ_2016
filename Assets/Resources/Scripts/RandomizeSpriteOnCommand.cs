using UnityEngine;
using System.Collections;

public class RandomizeSpriteOnCommand : MonoBehaviour {

	public Sprite[] mSprites;
	public int mustEqSize;
	public bool randomizeOnUpdate = false;
	public float chanceToRand = 1f;

	public void randomize()
	{
		int a = Random.Range (0, mustEqSize);
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = mSprites [a];
	}

	void Update() {

		if(randomizeOnUpdate && Random.value > (1-chanceToRand) ) {
			int a = Random.Range (0, mustEqSize);
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = mSprites [a];
		}

	}

}