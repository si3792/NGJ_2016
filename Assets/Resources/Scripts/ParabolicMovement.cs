using UnityEngine;
using System.Collections;

public class ParabolicMovement : MonoBehaviour {

	float a,b,c;
	bool move = false;
	float moveSpeed;
	Vector2 moveTarget;
	// Use this for initialization
	void Start () {
	
	}

	public void SetMoveTarget(Vector2 target, float speed, float maxh)
	{
		Vector2 cur = new Vector2 (transform.position.x, transform.position.y);
		a = (target.y - maxh - (cur.y - maxh) * target.x / cur.x) / (target.x*target.x - cur.x * target.x);
		b = (cur.y - maxh) / cur.x - a * cur.x;
		c = maxh;

		Debug.Log (a);
		Debug.Log (b);
		Debug.Log (c);
		Debug.Log (-b / 2.0f / a);
		move = true;
		moveSpeed = speed;
		if (target.x < cur.x)
			moveSpeed = -moveSpeed;
		moveTarget = target;
	}
	// Update is called once per frame
	void Update () {
		if (move) {
			Vector3 cur = transform.position;
			if (Vector2.Distance (new Vector2(cur.x,cur.y), moveTarget) < 1.0f) {
				move = false;
				return;
			}
			Debug.Log (cur);
			cur.x += moveSpeed * Time.deltaTime;
			cur.y = a * cur.x * cur.x + b * cur.x + c;
			transform.position = cur;
		}
	}
}
