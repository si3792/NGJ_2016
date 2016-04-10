using UnityEngine;
using System.Collections;

public class NuggetExtract : MonoBehaviour {

	public GameObject extractedNugget;
	public float extractTime = 0.25f;
	float timeToExtract;
	Collider2D zone;
	GameObject pl1,pl2;
	NuggetHandler pl1Nugs,pl2Nugs,nugs;
	// Use this for initialization
	void Start () {
		timeToExtract = extractTime;
		pl1 = GameObject.FindGameObjectWithTag ("Pl1");
		pl2 = GameObject.FindGameObjectWithTag ("Pl2");
		pl1Nugs = pl1.GetComponentInChildren<NuggetHandler> ();
		pl2Nugs = pl2.GetComponentInChildren<NuggetHandler> ();
		nugs = GetComponent<NuggetHandler> ();
		zone = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeToExtract -= Time.deltaTime;
		if (timeToExtract <= 0.0f) {
			timeToExtract = extractTime;
			if (pl1 != null && zone.IsTouching (pl1.GetComponent<CircleCollider2D> ()) && pl1Nugs.nuggets > 0) {
				pl1Nugs.nuggets--;
				nugs.nuggets++;
				GameObject.Instantiate (extractedNugget, pl1.transform.position, pl1.transform.rotation);
			}
			if (pl2 != null && zone.IsTouching (pl2.GetComponent<CircleCollider2D> ()) && pl2Nugs.nuggets > 0) {
				pl2Nugs.nuggets--;
				nugs.nuggets++;
				GameObject.Instantiate (extractedNugget, pl2.transform.position, pl2.transform.rotation);
			}
		}
	}
}
