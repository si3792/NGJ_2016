using UnityEngine;
using System.Collections;

public enum modes
{
	FollowPlayer = 1,
	FollowBoth = 2
};

public class CrossControl : MonoBehaviour
{

	public float distanceThreshold;
	public modes curMode = (modes) 1;
	Transform pl1;
	Transform pl2;
	Transform player;

	// Use this for initialization
	void Start ()
	{
		if(GameObject.FindGameObjectWithTag("Player") != null) {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		}
		if(GameObject.FindGameObjectWithTag("Pl1") != null) {
			pl1 = GameObject.FindGameObjectWithTag ("Pl1").transform;
		}
		if(GameObject.FindGameObjectWithTag("Pl2") != null) {
			pl2 = GameObject.FindGameObjectWithTag ("Pl2").transform;
		}
	
	}

	void FixedUpdate ()
	{

		if (curMode == modes.FollowPlayer) {
			// TODO - better cross movement depending on nearby important objects, etc
			transform.position = player.position;
		} 

		else if (curMode == modes.FollowBoth) {
			float distance = Vector3.Distance (pl1.position, pl2.position);

			if (distance < distanceThreshold) {

				//middle of two players
				transform.position = new Vector3 (pl1.position.x + (pl2.position.x - pl1.position.x)/2, 
					transform.position.y, transform.position.z
				);
			}

		}

	}

}
