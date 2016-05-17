﻿using UnityEngine;
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

	// p1 amd p2 armor ability
	public static bool p1armor = false;
	public static bool p2armor = false;
	public static float armorAmount = 50f;

	//p2 knockback bonus ability
	public static bool p2Knockback = true;
	public static float p2KnockbackAmount = 20f;
	public static float p2OtherKnockbackAmount = 40f;

	//p2 stronger walls ability
	public static bool p2wallBonus = false;
	public static float p2wallBonusAmount = 100f;

	// p1 healing mines ability
	public static bool p1healMines = true;
	public static float p1healMultiplier = 0.01f;

	//static variables are not reinitialized on scene reload
	void Awake() {
		PlayersSwitched = false;
		Players = 0;
	}



}
