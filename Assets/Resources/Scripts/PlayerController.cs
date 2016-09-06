using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, IDamageable {

	public float Health
	{
		get; 
		private set;
	}

	public TeamSide Team
	{
		get;
		private set;
	}

	public float MaxHP = 0f;
	public bool invulnerable = false;
	GameObject MainCam, SecondCam;
	CameraTellerScript cts;

	void Start () {
		this.Team = TeamSide.Players;
		MainCam = GameObject.FindGameObjectWithTag ("MainCamera");

		if(transform.parent.tag == "Pl2"  ) {
			this.Health = 120f;
			SecondCam = GameObject.FindGameObjectWithTag("CameraP1");

			if (GlobalData.p2armor == true)
				Health += GlobalData.armorAmount;

		} else {
			this.Health = 60f;
			if (GlobalData.p1armor == true)
				Health += GlobalData.armorAmount;

			SecondCam = GameObject.FindGameObjectWithTag("CameraP2");
		}
		cts = GameObject.FindGameObjectWithTag ("CameraTeller").GetComponent<CameraTellerScript>();


		if (MaxHP == 0) {
			MaxHP = Health;
		}
	}
		
    public void Kill(bool shouldDestroyObject) {
		if (shouldDestroyObject) {
			Destroy (transform.parent.gameObject);
		}

		GlobalData.Players--;
		Debug.Log ("Global data " + GlobalData.Players);
		if (GlobalData.Players <= 0) {
			// End Game
			GameObject.FindGameObjectWithTag ("Screenfader").GetComponent<ScreenfaderScript> ().sceneEnding = true;
			Debug.Log ("KUR");
		}
    }

	void Update () {
		if(Health <= 0) {
			this.Kill(true);
		}
	}

	public void Heal(float rawHeal) {
		this.Health = Mathf.Min(this.MaxHP, this.Health + rawHeal);
	}

	public void Damage(float rawDamage) {
		if (invulnerable) {
			return;
		}
		Health -= rawDamage;

		bool isPlayerOne = (transform.parent.tag == "Pl1") ? true : false;
		MainCam.GetComponent<pulseCamera>().MakeMePulse(0.2f);
		SecondCam = cts.getCameraForPlayer(isPlayerOne);
		SecondCam.GetComponent<pulseCamera>().MakeMePulse(0.2f);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "BeetleHurt") {
			//transform.parent.GetComponent<PlayerMovement> ().knockback (60, new Vector2 (transform.position.x - other.gameObject.transform.position.x, 0f));
		
			if(transform.parent.FindChild("pl1-shield") != null) {
				transform.parent.FindChild ("pl1-shield").GetComponent<ShieldScript> ().attemptShields ();
			}
		}
	}
}
