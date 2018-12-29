using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class AudioSync : NetworkBehaviour {

	private AudioSource source;

	public AudioClip[] clips;
	// Use this for initialization
	void Start () {
		source = this.GetComponent<AudioSource> ();
	}
	
	public void Playsound(int id){
		if (id >= 0 && id < clips.Length) {
		CmdSendServerSoundID (id);
	    }
	}

	[Command]
	void CmdSendServerSoundID(int id){
		RpcSendSoundIDTOClients (id);
	}

	[ClientRpc]
	void RpcSendSoundIDTOClients(int id){
		source.PlayOneShot (clips[id]);
	}

}
