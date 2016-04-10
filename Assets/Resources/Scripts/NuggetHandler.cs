using UnityEngine;
using System.Collections;

public class NuggetHandler : MonoBehaviour {

	public int nuggets = 200;
	public int NuggetsToWin;
	public int nuggetLeakRate = 1000;

	int iter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (iter >= nuggetLeakRate) {
			iter = 0;
			nuggets--;
		}
		iter++;
	}
}
