﻿using UnityEngine;
using System.Collections;

public class RandomizeSpriteOnCommand : MonoBehaviour {

	public Sprite[] mSprites;
	public int mustEqSize;

	public void randomize()
	{
		int a = Random.Range (0, mustEqSize);
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = mSprites [a];
	}

}