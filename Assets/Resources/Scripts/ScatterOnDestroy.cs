using UnityEngine;
using System.Collections;

public class ScatterOnDestroy : MonoBehaviour {

	public int mode = 0; // 1 - pl1 2 - pl2
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnDestroy() {

		if (mode == 1 && GlobalData.p1survived)
			return;

		if (mode == 2 && GlobalData.p2survived)
			return;


	
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		this.transform.DetachChildren ();

		foreach (Transform child in allChildren) {
			child.gameObject.AddComponent<Rigidbody2D> ();
			//child.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range (-3f, 3f), 10f), ForceMode2D.Impulse);
		}

	}
}
