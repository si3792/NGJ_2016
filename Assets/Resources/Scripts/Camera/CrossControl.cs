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
	public float OffsetFromSinglePlayer = 0f;
	Transform pl1;
	Transform pl2;

	Vector3? forcedFocus;

	public void ForceFocus(Vector3? focus) {
		forcedFocus = focus;
	}

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
		float f = -1f;
		if (forcedFocus != null) {
			transform.position = (Vector3) forcedFocus;
		} else if (curMode == modes.FollowPl1) {
			if (pl1 != null && pl1.GetComponent<PlayerMovement>().GetFacingRight()) {
				f *= -1;
			}
			Vector3 pos = pl1.position;
			pos.x += f * OffsetFromSinglePlayer;
			transform.position = pos;
		} else if (pl2 != null && curMode == modes.FollowPl2) {
			if (pl2.GetComponent<PlayerMovement>().GetFacingRight()) {
				f *= -1;
			}
			Vector3 pos = pl2.position;
			pos.x += f * OffsetFromSinglePlayer;
			transform.position = pos;
		}
		else if (pl1 != null && pl2 != null && curMode == modes.FollowBoth) {
			//middle of two players
			transform.position = new Vector3 (pl1.position.x + (pl2.position.x - pl1.position.x)/2, 
				transform.position.y, transform.position.z
			);
		}

	}

}
