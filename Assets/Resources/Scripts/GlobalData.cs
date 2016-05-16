using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour {
	public static bool PlayersSwitched = false;
	public static int Players = 0;

	public static bool developerBuild = true;

	public static bool musicOn = false;
	public static bool soundFXOn = true;

	public static int P1kills = 0;
	public static int P2kills = 0;
	public static int P1nuggets = 0;
	public static int P2nuggets = 0;
	public static float P1nuggetCombo = 0;
	public static float P2nuggetCombo = 0;

	public static bool p1survived = false;
	public static bool p2survived = false;


	//abilities
	public static bool p1armor = false;
	public static bool p2armor = false;
	public static float armorAmount = 50f;


	//static variables are not reinitialized on scene reload
	void Awake() {
		PlayersSwitched = false;
		Players = 0;
	}



}
