using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {
	public float speed;
	GameObject pl1,pl2;
	float col_radius;
	Rigidbody2D myRB;
	EnemyRegister enemy_reg;
	// Use this for initialization
	void Start () {
		
		pl1 = GameObject.FindGameObjectWithTag ("Pl1");
		pl2 = GameObject.FindGameObjectWithTag ("Pl2");
		enemy_reg = GetComponentInChildren<EnemyRegister> ();
		col_radius = GetComponent<CircleCollider2D> ().radius;
		myRB = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate()
	{
		float targetDist = Vector2.Distance(transform.position, pl1.transform.position);
		GameObject target = pl1;
		if( Vector2.Distance(transform.position, pl2.transform.position) < targetDist )
		{
			targetDist = Vector2.Distance (transform.position, pl2.transform.position);
			target = pl2;
		}

		if (targetDist > 1)
		{
			Vector2 pull = (target.transform.position - transform.position) * (1 /  targetDist); //the target tries to 'pull us in'
			Vector2 totalPush = Vector2.zero;

			int contenders = 0;
			foreach (GameObject enemy in enemy_reg.enemies)
			{

				//draw a vector from the obstacle to the ship, that 'pushes the ship away'
				Vector2 push = transform.position - enemy.transform.position;

				//calculate how much we are pushed away from this obstacle, the closer, the more push
				float distance = Vector2.Distance(transform.position, enemy.transform.position) - 2*col_radius;
				//only use push force if this object is close enough such that an effect is needed
				++contenders; //note that this object is actively pushing

				if (distance < 0.0001f) //prevent division by zero errors and extreme pushes
				{
					distance = 0.0001f;
				}
				float weight = 1 / distance;

				totalPush += push * weight;
			}

			pull *= Mathf.Max(1, 4 * contenders); //4 * contenders gives the pull enough force to pull stuff trough (tweak this setting for your game!)
			pull += totalPush;

			//Normalize the vector so that we get a vector that points in a certain direction, which we van multiply by our desired speed
			pull.Normalize();
			//Set the ships new position;
			myRB.AddForce( pull * speed * Time.deltaTime, ForceMode2D.Impulse );
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
