using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour {
	public static bool PlayersSwitched = false;
	public static int Players = 0;


	public static int P1kills = 0;
	public static int P2kills = 0;
	public static int P1nuggets = 0;
	public static int P2nuggets = 0;


	//static variables are not reinitialized on scene reload
	void Awake() {
		PlayersSwitched = false;
		Players = 0;
	}



}
