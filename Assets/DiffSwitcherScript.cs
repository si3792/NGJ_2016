using UnityEngine;
using System.Collections;

public class DiffSwitcherScript : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetInteger ("mode", GlobalData.gameMode);
		//Debug.Log ("Glo " + GlobalData.gameMode);
	}
}
