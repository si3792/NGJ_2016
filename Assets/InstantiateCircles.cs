using UnityEngine;
using System.Collections;

public class InstantiateCircles : MonoBehaviour {

	public GameObject circle;
	public float rangeminEmitter = -80;
	public float rangemaxEmitter = 90;
	public float chanceToSpawn = 0.6f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale < 0.05)
			return;
		
		if (Random.value > (1-chanceToSpawn))
			createCircle ();
	}

	void createCircle() {

		GameObject c;
		c = (GameObject) Instantiate (circle, transform.position + new Vector3 (Random.Range (rangeminEmitter, rangemaxEmitter), -100, 0), transform.rotation);
		c.transform.SetParent (transform);

		c = (GameObject) Instantiate (circle, transform.position + new Vector3 (Random.Range (rangeminEmitter, rangemaxEmitter), -100, 0), transform.rotation);
		c.transform.SetParent (transform);

		c = (GameObject) Instantiate (circle, transform.position + new Vector3 (Random.Range (rangeminEmitter, rangemaxEmitter), -100, 0), transform.rotation);
		c.transform.SetParent (transform);
	}

}
