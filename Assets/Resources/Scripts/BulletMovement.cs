using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float Speed;
	public float damage = 25;
	public string OwnerTag;
	public GameObject SpecialEffect = null;

	TeamSide Team = TeamSide.Players;

	void Update()
	{
		this.gameObject.transform.position += transform.right * Time.deltaTime * -Speed;

		if(Random.value > 0.2f)
		this.gameObject.GetComponent<RandomizeSpriteOnCommand> ().randomize ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
		if (damageable == null || damageable.Team == this.Team) {
			return;
		}

		damageable.Damage(this.damage);
		if (damageable.Health <= 0) {
			damageable.Kill(true);
			// Register kill
			if (OwnerTag == "Pl1") {
				GlobalData.P1kills++;
			} else if (OwnerTag == "Pl2") {
				GlobalData.P2kills++;
			}
		}

		if (SpecialEffect) {
			Instantiate(SpecialEffect, this.transform.position, Quaternion.Euler(Vector3.zero));
		}

		Destroy(this.gameObject);
	}
}