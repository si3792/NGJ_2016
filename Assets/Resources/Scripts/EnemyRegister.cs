using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyRegister : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerStay2D(Collider2D coll) 
	{
		EnemyRegister other_enemy = coll.gameObject.GetComponent<EnemyRegister> ();
		if( other_enemy )
		{
			GetComponentInParent<EnemyMovement>().addEnemyInfluance(coll.gameObject.transform.position);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
