using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class TouchRace : MonoBehaviour
{

	public bool isRacePressed = false;
	public bool isbrakePressed = false;
	public float direction = 1; // 1 - left 2 - up 3 - right 4 - down
	public bool shootControl = false;
	public bool mineControl = false;

	void Start () {

	}

	void Update () {
		if (isRacePressed )
		{
			if(direction == 1) {
			GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().moveL = true;
			}

			if(direction == 2) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().moveU = true;
			}

			if(direction == 3) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().moveR = true;
			}

			if(direction == 4) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().moveD = true;
			}

			if(shootControl) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().shootGun = true;
			}

			if(mineControl) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().dropMine = true;
			}
		}

		else if ( !isRacePressed )
		{
			if(direction == 1) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().moveL = false;
			}

			if(direction == 2) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().moveU = false;
			}

			if(direction == 3) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().moveR = false;
			}

			if(direction == 4) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().moveD = false;
			}

			if(shootControl) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().shootGun = false;
			}

			if(mineControl) {
				GameObject.FindGameObjectWithTag ("Pl1").gameObject.GetComponent<PlayerMovement> ().dropMine = false;
			}
		}
	}
	public void onPointerDownRaceButton()
	{
		isRacePressed = true;
	}
	public void onPointerUpRaceButton()
	{
		isRacePressed = false;
	}
}