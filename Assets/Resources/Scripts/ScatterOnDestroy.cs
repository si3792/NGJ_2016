using UnityEngine;
using System.Collections;

public class ScatterOnDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnDestroy() {
	
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		this.transform.DetachChildren ();

		foreach (Transform child in allChildren) {
			child.gameObject.AddComponent<Rigidbody2D> ();
			//child.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range (-3f, 3f), 10f), ForceMode2D.Impulse);
		}

	}
}
