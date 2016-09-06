using UnityEngine;
using System.Collections;

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

	void Start () {
		this.Team = TeamSide.Enemies;
		this.Health = 50f;
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
			Instantiate (deathSoundObj);
		}

		if (shouldDestroyObject) {
		    Destroy(gameObject.transform.parent.gameObject);
		}
	}

	// It's computationally expensive to keep this here because beetles collide all the time.
	// It is the logical location of the damage controller though... 
	void OnTriggerStay2D(Collider2D other) {
		IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
		if (damageable != null && damageable.Team == TeamSide.Players) {
		   damageable.Damage(3 * Time.deltaTime);
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
