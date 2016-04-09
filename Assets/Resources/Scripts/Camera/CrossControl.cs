using UnityEngine;
using System.Collections;

public enum modes
{
	FollowPl1 = 0,
	FollowPl2 = 1,
	FollowBoth = 2
};

public class CrossControl : MonoBehaviour
{

	public modes curMode = modes.FollowPl1;
	Transform pl1;
	Transform pl2;

	// Use this for initialization
	void Start ()
	{
		if(GameObject.FindGameObjectWithTag("Pl1") != null) {
			pl1 = GameObject.FindGameObjectWithTag ("Pl1").transform;
		}
		if(GameObject.FindGameObjectWithTag("Pl2") != null) {
			pl2 = GameObject.FindGameObjectWithTag ("Pl2").transform;
		}
	
	}

	void FixedUpdate ()
	{

		if (curMode == modes.FollowPl1) {
			transform.position = pl1.position;
		} else if (curMode == modes.FollowPl2) {
			transform.position = pl2.position;
		}
		else if (curMode == modes.FollowBoth) {
			//middle of two players
			transform.position = new Vector3 (pl1.position.x + (pl2.position.x - pl1.position.x)/2, 
				transform.position.y, transform.position.z
			);
		}

	}

}
