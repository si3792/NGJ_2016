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
	}
	
	// Update is called once per frame
	void Update () {
		
		mySR.sortingOrder = initial + (int) (transform.parent.transform.position.y * -100f) + offset;
	}
}
