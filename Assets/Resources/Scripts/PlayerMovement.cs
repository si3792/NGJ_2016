using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{


	public bool IsPlayerOne;
	public float Speed;

	Rigidbody2D myRB;
	bool facingRight = true;

	void Start ()
	{
		myRB = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate ()
	{
		myRB.velocity = getMovement ();

		if (myRB.velocity.x > 0 && !facingRight) {
			flip ();
		} else if (myRB.velocity.x < 0 && facingRight) {
			flip ();
		}
	}


	Vector2 getMovement ()
	{
		float h = 0, v = 0;

		if (IsPlayerOne) {

			if(Input.GetKey(KeyCode.LeftArrow) ) {
				h = -1 * Speed * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.RightArrow) ) {
				h = 1 * Speed * Time.deltaTime;
			}

			if(Input.GetKey(KeyCode.DownArrow) ) {
				v = -1 * Speed * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.UpArrow) ) {
				v = 1 * Speed * Time.deltaTime;
			}

		} else {

			if(Input.GetKey(KeyCode.A) ) {
				h = -1 * Speed * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.D) ) {
				h = 1 * Speed * Time.deltaTime;
			}

			if(Input.GetKey(KeyCode.S) ) {
				v = -1 * Speed * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.W) ) {
				v = 1 * Speed * Time.deltaTime;
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

}
