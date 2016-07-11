using UnityEngine;
using System.Collections;

public class TimedDeathAndOpacity : MonoBehaviour {

	public float timeToDie = 30f;
	private SpriteRenderer mySR;
	private float tmp;

	void Start () {
		tmp = timeToDie;
		mySR = GetComponent<SpriteRenderer> ();
		Destroy (this.gameObject, timeToDie);
		InvokeRepeating ("ReduceOpacity", 1f, 1f);
	}
	

	void ReduceOpacity () {
		mySR.color = new Color (1f, 1f, 1f, tmp/timeToDie + 0.2f );
		tmp--;
	}
}
