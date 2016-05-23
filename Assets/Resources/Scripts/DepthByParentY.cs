using UnityEngine;
using System.Collections;

public class DepthByParentY : MonoBehaviour {

	SpriteRenderer mySR;
	int initial;
	public int offset = 0;
	// Use this for initialization
	void Start () {
		mySR = this.GetComponent<SpriteRenderer> ();
		initial = mySR.sortingOrder;

		InvokeRepeating ("SlowedUpdate", 0f, 0.2f);
	}

	void SlowedUpdate() {
		if (transform.parent == null)
			return;
		mySR.sortingOrder = initial + (int) (transform.parent.transform.position.y * -100f) + offset;
	}

	// Update is called once per frame
	void Update () {


	}
}
