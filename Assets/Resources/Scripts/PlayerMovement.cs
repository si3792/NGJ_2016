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
	private PlayerController playerController;
	//public bool pl2WalkToggle = true;
	float knockbackReleaseThreshold = 0.4f;
	bool player2ShootIntent = false;

	void Awake() {
		player1Alive = true;
		player2Alive = true;

		if(!IsPlayerOne) {

			if(GlobalData.p2massAbility) {
				GetComponent<Rigidbody2D> ().mass = GlobalData.p2massAmount;
			}
		}

	}


	Rigidbody2D myRB;
	public bool FacingRight
	{
		get; private set;
	}

	// keep track of drag
	float startingDrag;
	GameObject muzzleFlashP1;

	void dash() {

		var dir = new Vector2 ( (FacingRight)? 1:-1  , 0);
		myRB.AddForce ( dir * 2500 * Time.deltaTime, ForceMode2D.Impulse);
	}


	void Start ()
	{
		playerController = GetComponentInChildren<PlayerController>();
		FacingRight = true;
		if (GlobalData.PlayersSwitched) {
			IsPlayerOne = !IsPlayerOne;
		}
		GlobalData.Players++;
		muzzleFlashP1 = GameObject.FindGameObjectWithTag ("p1-muzzle-flash");
		myRB = GetComponent<Rigidbody2D> ();
		startingDrag = myRB.drag;

		if (!IsPlayerOne)
			myAnim = transform.Find ("RedObject").gameObject.GetComponent<Animator> ();
		else
			myAnim = transform.Find ("BlueObject").transform.GetChild(0).gameObject.GetComponent<Animator> ();

		// ability cd 
		if(IsPlayerOne && GlobalData.p1cdAbility) {
			specialCooldown -= GlobalData.cdAbilityAmount;
		} else  
			if( (!IsPlayerOne) && GlobalData.p2cdAbility) {
			specialCooldown -= GlobalData.cdAbilityAmount;
		} 

		Speed *= myRB.mass;
			
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
			if(Input.GetKey(KeyCode.Space) || Input.GetAxis("RightTriggerP2") > 0) {
				myAnim.SetBool("Shoot", true);
				player2ShootIntent = true;

			} else {
				myAnim.SetBool ("Shoot", false);
				player2ShootIntent = false;
			}
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetAxis("LeftTriggerP2") > 0)
			{
				if (curCooldownSpecial <= 0.0f) {
					useSpecial ();
					curCooldownSpecial = specialCooldown;
				}
			}
		} else  {

			//shoot pl1
			if( (Input.GetKey(KeyCode.Return) || Input.GetAxis("RightTriggerP1") > 0) && GlobalData.overheatLock == false ) {
				myAnim.SetBool("Shoot", true);
				Speed = P1ShootWalkSpeed;

				// show muzzle
				muzzleFlashP1.GetComponent<SpriteRenderer> ().enabled = true;

			} else {
				myAnim.SetBool ("Shoot", false);
				Speed = P1WalkSpeed;

				muzzleFlashP1.GetComponent<SpriteRenderer> ().enabled = false;
			}
			if (Input.GetKey (KeyCode.RightShift) || Input.GetAxis("LeftTriggerP1") > 0)
			{
				if (curCooldownSpecial <= 0.0f) {
					useSpecial ();
					curCooldownSpecial = specialCooldown;
				}
			}

		}

		//test knockback
		if(Input.GetKeyDown(KeyCode.K) && GlobalData.developerBuild) {
			Vector2 direction = FacingRight ? Vector2.right : Vector2.left;
			knockback (40, direction);
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

			if(!player2ShootIntent) {
				myRB.AddForce (mv * Speed, ForceMode2D.Impulse);
				if(mv != Vector2.zero) myAnim.SetFloat("ms", 1);
			}

		}





		// flip character to face direction
		if (mv.x > 0 && !FacingRight) {
			flip ();
		} else if (mv.x < 0 && FacingRight) {
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
		FacingRight = !FacingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;

	}


	public void knockback(float strength, Vector2 direction) {
		inKnockback = true;
		playerController.AttemptShields();
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
			if (FacingRight) {
				pos.x += 0.7f;
			}
			else {
				pos.x -= 0.7f;
			}
		}
		GameObject.Instantiate (specialObject, pos, transform.rotation);
	}


}
