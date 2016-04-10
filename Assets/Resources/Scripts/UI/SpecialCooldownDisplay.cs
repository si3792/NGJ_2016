using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpecialCooldownDisplay : MonoBehaviour {
	public string PlayerTag;
	Image thisImage;
	PlayerMovement player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(PlayerTag).GetComponent<PlayerMovement>();
		thisImage = this.gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		thisImage.fillAmount = Mathf.Min(1f, 1.2f * player.curCooldownSpecial / player.specialCooldown);
	}
}
