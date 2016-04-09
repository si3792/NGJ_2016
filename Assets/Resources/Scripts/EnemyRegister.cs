using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyRegister : MonoBehaviour {
	public class EnemyReference
	{
		public GameObject enemy;
		public bool valid;
		public EnemyReference(GameObject e)
		{
			enemy = e;
			valid = true;
		}
	}

	public EnemyReference r; 
	EnemyMovement mov;
	// Use this for initialization
	void Start () {
		r = new EnemyReference (gameObject);
		mov = GetComponentInParent<EnemyMovement> ();
	}
	void OnTriggerEnter2D(Collider2D coll) 
	{
		EnemyRegister other_enemy = coll.gameObject.GetComponent<EnemyRegister> ();
		if( other_enemy && mov )
		{
			mov.enemies.Add(other_enemy.r);
		}
	}
	void OnTriggerExit2D(Collider2D coll) 
	{
		EnemyRegister other_enemy = coll.gameObject.GetComponent<EnemyRegister> ();
		if( other_enemy && mov )
		{
			mov.enemies.Remove(other_enemy.r);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnDestroy()
	{
		r.valid = false;
	}
}
