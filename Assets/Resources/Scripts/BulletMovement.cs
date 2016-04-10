using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float Speed;
	public float damage = 25;


	void Update()
	{
		this.gameObject.transform.position += transform.right * Time.deltaTime * -Speed;

		if(Random.value > 0.2f)
		this.gameObject.GetComponent<RandomizeSpriteOnCommand> ().randomize ();
	}

}