using UnityEngine;
using System.Collections;

public class popText : MonoBehaviour {

	bool popping = false;
	public float popAmount, popSpeed;
	float curPop = 1;
	float threshold = 0.1f;
	Vector3 initScale;

	void Start() {
		initScale = transform.localScale;
	}

	public void Pop() {
		popping = true;
	}


	void Update() {

		if(popping == true) {
			curPop = Mathf.Lerp (curPop, popAmount, Time.deltaTime * popSpeed);
			if (curPop > popAmount - threshold)
				popping = false;

		} else {
			curPop = Mathf.Lerp (curPop, 1, Time.deltaTime * popSpeed);
		}



		transform.localScale = initScale * curPop;
	}


}
