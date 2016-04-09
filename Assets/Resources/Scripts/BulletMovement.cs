using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float Speed;
	public float damage = 50;

	void Update()
	{
		this.gameObject.transform.position += transform.up * Time.deltaTime * Speed;

	}

}