using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlackTransparentUI : MonoBehaviour {

	public float Alpha;

	// Use this for initialization
	void Start () {
		var image = this.GetComponent<Image>();
		var c = Color.black;
		c.a = Alpha;
		image.color = c;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
