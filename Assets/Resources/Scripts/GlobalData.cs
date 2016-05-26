using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour {
	public static bool PlayersSwitched = false;
	public static int Players = 0;

	public static bool developerBuild = false;

	public static bool musicOn = false;
	public static bool soundFXOn = true;

	public static int P1kills = 4310;
	public static int P2kills = 1337;
	public static int P1nuggets = 140;
	public static int P2nuggets = 302;
	public static float P1nuggetCombo = 0;
	public static float P2nuggetCombo = 0;

	public static bool p1survived = false;
	public static bool p2survived = false;

	//GAME MODE
	public static int gameMode = 0; // 0 - normal, 1 - hard, 2 - hof

	//abilities

	// p1 amd p2 armor ability
	public static bool p1armor = false;
	public static bool p2armor = false;
	public static float armorAmount = 50f;

	// p1 amd p2 ability cd ability
	public static bool p1cdAbility = true;
	public static bool p2cdAbility = false;
	public static float cdAbilityAmount = 1f;

	//p2 knockback bonus ability
	public static bool p2Knockback = true;
	public static float p2KnockbackAmount = 20f;
	public static float p2OtherKnockbackAmount = 40f;

	//p2 stronger walls ability
	public static bool p2wallBonus = false;
	public static float p2wallBonusAmount = 100f;

	// p1 healing mines ability
	public static bool p1healMines = false;
	public static float p1healMultiplier = 0.01f;

	// p1 shield ability
	public static bool p1shield = false;

	// pl2 mass increase ability
	public static bool p2massAbility = true;
	public static float p2massAmount = 10f;


	//static variables are not reinitialized on scene reload
	void Awake() {
		PlayersSwitched = false;
		Players = 0;
	}



}
