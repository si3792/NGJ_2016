using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour {

	public string PlayerTag;
	GameObject hpShow;
	PlayerController hpObj;
	void Start() {
		hpObj = GameObject.FindGameObjectWithTag(PlayerTag).GetComponentInChildren<PlayerController>();

		if (PlayerTag == "Pl1")
			hpShow = GameObject.FindGameObjectWithTag ("blueHPShow");
		else
			hpShow = GameObject.FindGameObjectWithTag ("redHPShow");
	}


	void Update () {
		if (hpObj != null) {
			this.gameObject.GetComponent<Image>().fillAmount = hpObj.Health / hpObj.MaxHP;

			hpShow.GetComponent<Text>().text = Mathf.RoundToInt(hpObj.Health).ToString()  + "/" + hpObj.MaxHP.ToString();

		} else {
			this.gameObject.GetComponent<Image> ().fillAmount = 0; //.001f;
		}
	}
}
