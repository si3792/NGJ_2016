using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyRegister : MonoBehaviour {

	Collider2D swarm_col;
	public List<GameObject> enemies;
	// Use this for initialization
	void Start () {
		enemies = new List<GameObject> ();
		swarm_col = GetComponent<CircleCollider2D> ();
	}
	void OnTriggerEnter2D(Collider2D coll) 
	{
		EnemyRegister other_enemy = coll.gameObject.GetComponent<EnemyRegister> ();
		if( other_enemy )
		{
			enemies.Add (coll.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		EnemyRegister other_enemy = coll.gameObject.GetComponent<EnemyRegister> ();
		if( other_enemy )
		{
			enemies.Remove(coll.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy()
	{
		foreach (GameObject enemy in enemies) {
			enemy.GetComponent<EnemyRegister>().enemies.Remove(gameObject);
		}
	}
}
