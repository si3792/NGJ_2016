using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour {

	public string PlayerTag;
	PlayerController hpObj;
	void Start() {
		hpObj = GameObject.FindGameObjectWithTag(PlayerTag).GetComponentInChildren<PlayerController>();
	}


	void Update () {
		if (hpObj != null) {
			this.gameObject.GetComponent<Image>().fillAmount = hpObj.health / hpObj.MaxHP;
		} else {
			this.gameObject.GetComponent<Image>().fillAmount = 0.005f;
		}
	}
}
