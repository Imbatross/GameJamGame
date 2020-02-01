using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour {
	public int nexusTeam = 1; //1 is player 1, 2 is player 2
	private int nexusHealth = 5;

	//React to enemy robots
	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.GetComponent<Robot>()) {
			Robot contactedRobot = collision.gameObject.GetComponent<Robot>();

			if ((contactedRobot.activated == true) && (contactedRobot.player != nexusTeam)) { //if robot is activated and doesnt belong to the same team as the nexus
				DamageNexus(1);
				//then kill/destroy robot here using the death function in the robot
			}
		}
	}

	//Subtract HP from Nexus
	private void DamageNexus(int amount) {
		nexusHealth -= amount;
	}

	//Get HP of Nexus
	public int GetHealth() {
		return nexusHealth;
	}
}