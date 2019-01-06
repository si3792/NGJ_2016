using UnityEngine;
using System.Collections;

public class BugMove : MonoBehaviour {

	public float speed;
	SpriteRenderer mySR;

	void Start() {
		mySR = gameObject.GetComponent<SpriteRenderer> ();
	}

	void Update () {
		if (
            mySR.sprite.name == "Untitled-1_0000_Layer-9" 
            || mySR.sprite.name == "Untitled-1_0001_Layer-8" 
            || mySR.sprite.name == "Untitled-1_0002_Layer-6"
            || mySR.sprite.name == "Untitled-1_0003_Layer-5") {
            return;
        }

        transform.Translate (new Vector3 (speed * Time.deltaTime,  speed * Time.deltaTime / 5, 0));
	}
}
