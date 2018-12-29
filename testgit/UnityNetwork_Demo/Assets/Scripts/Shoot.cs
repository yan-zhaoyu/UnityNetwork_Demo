using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSync))]
public class Shoot : NetworkBehaviour {

	private SetupLocalPlayer audioSync;

	void Start () {
		audioSync = this.GetComponent<SetupLocalPlayer> ();
	}

	void Update () {
		if (isLocalPlayer) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				audioSync.Playsound (0);
			} else if (Input.GetKeyDown (KeyCode.E)) {
				audioSync.Playsound (1);
			} else if (Input.GetKeyDown (KeyCode.X)) {
				audioSync.Playsound (-1);
			}
		}
	}
}
