using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour {

	public string PlayerTag = "pl-hurtbox";
	public float deadBarFraction;

	void Update () {
		var playerObj = GameObject.FindGameObjectWithTag(PlayerTag);
		PlayerController hpObj = null;
		if (playerObj != null) {
			hpObj = playerObj.GetComponent<PlayerController>();
		}
		if (hpObj != null) {
			this.gameObject.GetComponent<Image>().fillAmount = hpObj.health / 100;
		} else {
			this.gameObject.GetComponent<Image>().fillAmount = 0.005f;
		}
	}
}
