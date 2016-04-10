using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public static bool player1Alive = true;
	public static bool player2Alive = true;

	public bool IsPlayerOne;
	public float Speed;
	public Animator myAnim;

	bool inKnockback = false;
	//public bool pl2WalkToggle = true;
	float knockbackReleaseThreshold = 0.4f;

	Rigidbody2D myRB;
	bool facingRight = true;

	// keep track of drag
	float startingDrag;


	void Start ()
	{

		myRB = GetComponent<Rigidbody2D> ();
		startingDrag = myRB.drag;

		if(!IsPlayerOne)
		myAnim = transform.Find ("RedObject").gameObject.GetComponent<Animator> ();
	}

	public bool GetFacingRight() {
		return facingRight;
	}

	void FixedUpdate ()
	{
		if (!IsPlayerOne) {
			myAnim.SetFloat ("ms", 0);

			//shoot

			if(Input.GetKey(KeyCode.LeftControl)) {
				myAnim.SetBool("Shoot", true);
			} else {
				myAnim.SetBool ("Shoot", false);
			}


		}

		//test knockback
		if(Input.GetKeyDown(KeyCode.K)) {
			knockback (40, Vector2.right);
		}

		//disable movement while knockbacked
		if(inKnockback) {
			if (myRB.velocity.x < knockbackReleaseThreshold && myRB.velocity.y < knockbackReleaseThreshold) {
				inKnockback = false;
				myRB.drag = startingDrag;
			}

			return;
		}

		// basic UDLR movement
		var mv = getMovementVector ();

		if(IsPlayerOne) {
			myRB.AddForce (mv * Speed, ForceMode2D.Impulse);

		} else {

			//if(pl2WalkToggle) {
				myRB.AddForce (mv * Speed, ForceMode2D.Impulse);
			//}

			//animator
			if(mv != Vector2.zero) myAnim.SetFloat("ms", 1);
		}

	 

			

		// flip character to face direction
		if (myRB.velocity.x > 0 && !facingRight) {
			flip ();
		} else if (myRB.velocity.x < 0 && facingRight) {
			flip ();
		}
	}


	Vector2 getMovementVector ()
	{
		float h = 0, v = 0;

		if (IsPlayerOne) {

			if(Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("HorizontalP1") < 0) {
				h = -1  * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("HorizontalP1") > 0) {
				h = 1  * Time.deltaTime;
			}

			if(Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("VerticalP1") < 0) {
				v = -1  * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("VerticalP1") > 0) {
				v = 1  * Time.deltaTime;
			}

		} else {

			if(Input.GetKey(KeyCode.A) || Input.GetAxis("HorizontalP2") < 0) {
				h = -1  * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.D) || Input.GetAxis("HorizontalP2") > 0) {
				h = 1  * Time.deltaTime;
			}

			if(Input.GetKey(KeyCode.S) || Input.GetAxis("VerticalP2") < 0) {
				v = -1  * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.W) || Input.GetAxis("VerticalP2") > 0) {
				v = 1  * Time.deltaTime;
			}

		}

		return new Vector2 (h, v);
	}


	void flip ()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;

	}


	public void knockback(float strength, Vector2 direction) {

		inKnockback = true;
		myRB.drag = 10; // drag is changed during knockback
		myRB.AddForce(strength * direction * (1/Time.timeScale), ForceMode2D.Impulse);
	}

	void OnDestroy()
	{
		if (IsPlayerOne)
			player1Alive = false;
		else
			player2Alive = false;
	}
		



}
