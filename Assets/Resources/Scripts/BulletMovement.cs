﻿using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float Speed;

	void Update()
	{
		this.gameObject.transform.position += transform.up * Time.deltaTime * Speed;

	}
}