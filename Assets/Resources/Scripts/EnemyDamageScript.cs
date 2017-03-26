using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDamageScript : MonoBehaviour, IDamageable {

	public TeamSide Team
	{
		get;
		private set;
	}
	public float Health
	{
		get;
		private set;
	}

	public float biomassSpawnChance = 0.6f;
	public float dps = 3.0f;
	// The time between two consecutive damage operations in seconds.
	// Higher values mean better performance, lower mean smoother damaging.
	public float damageCheckInterval = 0.1f;
	// The time before bugs are allowed to deal damage in seconds.
	public float initialDamageWait = 2f;
	public float HP = 50f;
	bool died = false;
	public GameObject biomassDrop;
	public GameObject psFx;
	public float pl2BulletDamage;
	public GameObject explosion;
	public AudioClip death1;
	public AudioClip death2;
	public GameObject soundPlayer;
	public GameObject deathSoundObj;
	public bool lastDMGPl1 = true;

	private Dictionary<int, IDamageable> collidingEnemies = new Dictionary<int, IDamageable>();

	void Start () {
		this.Team = TeamSide.Enemies;
		this.Health = HP;
		// Add 25% random jitter to avoid bugs synchronizing their attacks.
		InvokeRepeating("DamageAllCollidingEnemies",
			initialDamageWait + (Random.value * initialDamageWait / 4),
			damageCheckInterval + (Random.value * damageCheckInterval / 4));
	}

	// For use from external sources
	public void Damage(float dmg) {
		Health -= dmg;
	}

	public void Kill(bool shouldDestroyObject) {
		died = true;

		//chance to spawn biomass nugget
		if(Random.value > biomassSpawnChance) {
			Instantiate (biomassDrop, transform.position, Quaternion.Euler (Vector3.zero));
		}

		//ps @Simo WTF is this?
		Instantiate(psFx, transform.position, Quaternion.Euler(Vector3.zero));

		if(GlobalData.soundFXOn) {
			Instantiate(deathSoundObj);
		}

		if (shouldDestroyObject) {
		    Destroy(gameObject.transform.parent.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
		if (damageable != null && damageable.Team == TeamSide.Players) {
			collidingEnemies.Add(damageable.GetHashCode(), damageable);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
		if (damageable != null && damageable.Team == TeamSide.Players) {
			collidingEnemies.Remove(damageable.GetHashCode());
		}
	}

	void DamageAllCollidingEnemies() {
		foreach (IDamageable enemy in collidingEnemies.Values) {
			enemy.Damage(dps * damageCheckInterval);
		}
	}

	void Update() {
		if (Health <= 0 && died == false) {
			this.Kill(true);
		}
	}

	void OnDestroy()
	{
		WaveSpawn.bugCount--;
	}

	void PlayDeathSound() {
		var clip = death1;
		if (Random.value < 0.5) {
			clip = death2;
		}
		var player = Instantiate(soundPlayer);
		player.GetComponent<SingleSound>().clip = clip;
	}

}
