using UnityEngine;
using System.Collections;

public class WallDamage : MonoBehaviour, IDamageable {

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

	public GameObject boom;
	// Use this for initialization
	void Start () {
		Team = TeamSide.Players;
		Health = 100f;
		if(GlobalData.p2wallBonus) {
			Health += GlobalData.p2wallBonusAmount;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Health <= 0.0f) {
			this.Kill(true);
		}
	}

	public void Damage(float damageReceived)
	{
		// Walls die three times as fast as players. (shold they?)
		Health -= 3.33f * damageReceived;
	}

	public void Kill(bool shouldDestroyObject) {
		Instantiate (boom, transform.position, Quaternion.Euler (Vector3.zero));
		Instantiate (boom, transform.position, Quaternion.Euler (Vector3.zero));
		if (shouldDestroyObject) {
			Destroy (transform.parent.gameObject);
		}
	}
}
