using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pulseFontColor : MonoBehaviour {

	public Color c1;
	public Color c2;
	public float speed;
	bool blendUp = true;
	public float cnt;

	void Start () {
		GetComponent<Text> ().color = c1;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(blendUp) {
			GetComponent<Text>().color = Color.Lerp (GetComponent<Text>().color, c2, cnt *  Time.deltaTime);
			cnt += speed * Time.deltaTime;
			if (GetComponent<Text> ().color == c2) {
				blendUp = false;
				cnt = 0;
			}
		} else {
					GetComponent<Text>().color = Color.Lerp (GetComponent<Text>().color, c1, cnt * Time.deltaTime);
			if (GetComponent<Text> ().color == c1) {
				blendUp = true;
				cnt = 0;
			}
			cnt += speed * Time.deltaTime;
		}
	}
}
