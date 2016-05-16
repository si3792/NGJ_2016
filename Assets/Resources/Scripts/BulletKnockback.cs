using UnityEngine;
using System.Collections;

public class BulletKnockback : MonoBehaviour {

	public float distance;
	public float strength;
	Vector2 direction;
	float strengthBonus = 0;

	void OnDestroy() {

		strengthBonus = (GlobalData.p2Knockback) ? GlobalData.p2OtherKnockbackAmount : 0f;

		foreach(GameObject go in GameObject.FindGameObjectsWithTag("BeetleHurt") ) {

			if(Vector3.Distance(go.transform.position, transform.position) < distance) {

				direction = go.transform.position - transform.position;
				go.GetComponent<Rigidbody2D>(). AddForce( (strength + strengthBonus ) * direction * (1/Time.timeScale) * (1/distance), ForceMode2D.Impulse);
				go.transform.Find ("hurtbox").GetComponent<EnemyDamageScript> ().health -= 50 / distance;
				if (go.transform.Find ("hurtbox").GetComponent<EnemyDamageScript> ().health < 0)
					go.transform.Find ("hurtbox").GetComponent<EnemyDamageScript> ().lastDMGPl1 = false;
			}

		}

	}

}
