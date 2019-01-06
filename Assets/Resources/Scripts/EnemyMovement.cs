using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {
	public HashSet<EnemyRegister.EnemyReference> enemies;
	public float speed;
	GameObject pl1,pl2;
	float col_radius;
	Rigidbody2D myRB;
	Animator anim;
	float slowAmount = 0.1f;
	// Use this for initialization
	void Start () {
		enemies = new HashSet<EnemyRegister.EnemyReference> ();
		pl1 = GameObject.FindGameObjectWithTag("Pl1");
		pl2 = GameObject.FindGameObjectWithTag("Pl2");
		col_radius = GetComponent<CircleCollider2D>().radius;
		myRB = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
		target = pl1;
		targetDist = float.MaxValue; 

		InvokeRepeating("SlowedUpdate", 0f, slowAmount);
	}
	float targetDist;
	float targetAngle = 1.0f;
	GameObject target;


	void SlowedUpdate() {
		// Doesnt calculate target every frame
		if (target == null)
			targetDist = float.MaxValue;
		else
			targetDist = Vector2.Distance(transform.position, target.transform.position);

		if (pl1 != null) {
			if (targetDist > Vector2.Distance(transform.position, pl1.transform.position)) {	
				target = pl1;
				targetDist = Vector2.Distance(transform.position, pl1.transform.position);
			}
		}
		if (pl2 != null) {
			if (Vector2.Distance(transform.position, pl2.transform.position) < targetDist) {
				target = pl2;
				targetDist = Vector2.Distance (transform.position, pl2.transform.position);
			}
		}

		if (pl1 == null && pl2 == null)
			target = GameObject.FindGameObjectWithTag("the-ship"); // Replace with sth else

		if (target.transform.position.x < transform.position.x) {
			targetAngle = -1.0f;
		} else {
			targetAngle = 1.0f;
		}

		if (targetDist > 1)
		{
			Vector2 totalPush = Vector2.zero;
			int contenders = 0;
			List<EnemyRegister.EnemyReference> to_remove = new List<EnemyRegister.EnemyReference> ();
			foreach (EnemyRegister.EnemyReference enemy in enemies) {
				if ( enemy == null ) {
					continue;
				}
				if (enemy.valid == false) {
					to_remove.Add (enemy);
					continue;
				}
				Vector3 pos = enemy.enemy.transform.position;
				Vector2 push = transform.position - pos;

				//calculate how much we are pushed away from this obstacle, the closer, the more push
				float distance = Vector2.Distance (transform.position, pos) - 2 * col_radius;
				//only use push force if this object is close enough such that an effect is needed
				++contenders; //note that this object is actively pushing

				if (distance < 0.0001f) { //prevent division by zero errors and extreme pushes
					distance = 0.0001f;
				}
				float weight = 1 / distance;

				totalPush += push * weight;
			}
			foreach (EnemyRegister.EnemyReference r in to_remove) {
				enemies.Remove (r);
			}
			Vector2 pull = (target.transform.position - transform.position) * (1 /  targetDist); //the target tries to 'pull us in'

			pull *= Mathf.Max(1, 4 * contenders); //4 * contenders gives the pull enough force to pull stuff trough (tweak this setting for your game!)
			pull += totalPush;

			//Normalize the vector so that we get a vector that points in a certain direction, which we van multiply by our desired speed
			pull.Normalize();
			//Set the ships new position;
			myRB.AddForce( pull * speed * slowAmount, ForceMode2D.Impulse );
		}
	}

	void FixedUpdate()
	{




	}
	public void SwitchTarget(GameObject target)
	{
		this.target = target;
		targetDist = Vector2.Distance (transform.position, target.transform.position);
	}
	// Update is called once per frame
	void Update () {
		transform.localScale = 
            new Vector3(targetAngle, transform.localScale.y, transform.localScale.z);
		anim.SetFloat("playerDist", targetDist);
	}
}
