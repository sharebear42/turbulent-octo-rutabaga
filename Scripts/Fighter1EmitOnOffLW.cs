﻿using UnityEngine;
using System.Collections;

public class Fighter1EmitOnOffLW : MonoBehaviour 
{
	/// <summary>
	/// Controls the thruster object on the side of the fighter pointing forwards, opposite to the direction of the forward thrusters.
	/// Applies force to the attached rigidbody, which is itelf attached to the fighter parent parent object by a fixed joint.
	/// </summary>
	
	public float lThrust;
	
	private GameController gameController;		// gets the gamecontroller script in order to access the gameStart1 and 2 variables.

	void Start ()
	{
		GetComponent<Renderer>().enabled = false;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();

	}

	void Update()
	{
		if (gameController.gameStart1 == true) {			// enables the particle system and the audiosource if the ship is rotating.	

			if (Input.GetKey (KeyCode.D)) {
				GetComponent<Rigidbody> ().AddRelativeForce ((Vector3.back * lThrust * Time.deltaTime), ForceMode.Impulse);	// force applied.
				GetComponent<Renderer> ().enabled = true;
				GetComponent<AudioSource> ().mute = false;
			} else if (Input.GetKey (KeyCode.S)) {
				GetComponent<Rigidbody> ().AddRelativeForce ((Vector3.back * lThrust * Time.deltaTime), ForceMode.Impulse);
				GetComponent<Renderer> ().enabled = true;		// the particle system is enabled when the ship is given backward thrust.
				GetComponent<AudioSource> ().mute = false;		// the audiosource is un-muted.
			} else {
				GetComponent<Renderer> ().enabled = false;
				GetComponent<AudioSource> ().mute = true;
			} 
		}
	}
}
