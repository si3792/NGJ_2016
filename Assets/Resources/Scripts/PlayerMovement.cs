using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public static bool player1Alive = true;
	public static bool player2Alive = true;

	public bool IsPlayerOne;
	public float Speed;
	public float P1ShootWalkSpeed;
	public float P1WalkSpeed;
	public Animator myAnim;
	public bool canDash = false;
	public float specialCooldown = 5.0f;
	public float curCooldownSpecial = 0.0f;
	bool inKnockback = false;
	public GameObject specialObject;
	//public bool pl2WalkToggle = true;
	float knockbackReleaseThreshold = 0.4f;

	Rigidbody2D myRB;
	bool facingRight = true;

	// keep track of drag
	float startingDrag;
	GameObject muzzleFlashP1;

	void dash() {

		var dir = new Vector2 ( (facingRight)? 1:-1  , 0);
		myRB.AddForce ( dir * 2500 * Time.deltaTime, ForceMode2D.Impulse);
	}


	void Start ()
	{
		muzzleFlashP1 = GameObject.FindGameObjectWithTag ("p1-muzzle-flash");
		myRB = GetComponent<Rigidbody2D> ();
		startingDrag = myRB.drag;

		if (!IsPlayerOne)
			myAnim = transform.Find ("RedObject").gameObject.GetComponent<Animator> ();
		else
			myAnim = transform.Find ("BlueObject").transform.GetChild(0).gameObject.GetComponent<Animator> ();
	}	

	public bool GetFacingRight() {
		return facingRight;
	}

	void FixedUpdate ()
	{
		//Debug.Log(Input.GetAxis("RightTriggerP2"));

		// basic UDLR movement
		var mv = getMovementVector ();

		myAnim.SetFloat ("ms", 0);

		if (!IsPlayerOne) {

			// dash
			if((Input.GetKeyDown(KeyCode.F) || Input.GetAxis("LeftBumperP2") > 0) && canDash) {

				dash ();
				myAnim.SetBool ("Dash", true);

			} else {
				myAnim.SetBool ("Dash", false);
			}

			//shoot pl2
			if(Input.GetKey(KeyCode.LeftControl) || Input.GetAxis("RightTriggerP2") != 0) {
				myAnim.SetBool("Shoot", true);

			} else {
				myAnim.SetBool ("Shoot", false);
			}
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetAxis("LeftTriggerP2") != 0)
			{
				if (curCooldownSpecial <= 0.0f) {
					useSpecial ();
					curCooldownSpecial = specialCooldown;
				}
			}
		} else  {

			//shoot pl1
			if(Input.GetKey(KeyCode.RightControl) || Input.GetAxis("RightTriggerP1") > 0) {
				myAnim.SetBool("Shoot", true);
				Speed = P1ShootWalkSpeed;

				// show muzzle
				muzzleFlashP1.GetComponent<SpriteRenderer> ().enabled = true;

			} else {
				myAnim.SetBool ("Shoot", false);
				Speed = P1WalkSpeed;

				muzzleFlashP1.GetComponent<SpriteRenderer> ().enabled = false;
			}
			if (Input.GetKey (KeyCode.RightShift) || Input.GetAxis("LeftTriggerP1") != 0)
			{
				if (curCooldownSpecial <= 0.0f) {
					useSpecial ();
					curCooldownSpecial = specialCooldown;
				}
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



		if(IsPlayerOne) {
			myRB.AddForce (mv * Speed, ForceMode2D.Impulse);

			if(mv != Vector2.zero) myAnim.SetFloat("ms", 1);

		} else {

			//if(pl2WalkToggle) {
				myRB.AddForce (mv * Speed, ForceMode2D.Impulse);
			//}

			//animator
			if(mv != Vector2.zero) myAnim.SetFloat("ms", 1);
		}

	 

			

		// flip character to face direction
		if (mv.x > 0 && !facingRight) {
			flip ();
		} else if (mv.x < 0 && facingRight) {
			flip ();
		}

		if (curCooldownSpecial > 0.0f) {
			curCooldownSpecial -= Time.fixedDeltaTime;
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
		
	void useSpecial()
	{
		Vector3 pos = transform.position;
		if (!IsPlayerOne) {
			if (facingRight)
				pos.x += 0.7f;
			else
				pos.x -= 0.7f;
		}
		GameObject.Instantiate (specialObject, pos, transform.rotation);
	}


}
