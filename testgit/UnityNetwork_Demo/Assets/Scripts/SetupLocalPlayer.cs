using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class SetupLocalPlayer : NetworkBehaviour {

	private AudioSource source;
	public AudioClip[] clips;

	[SyncVar]
	public string pname = "Player";

	void OnGUI(){
		if(isLocalPlayer){
		pname = GUI.TextField (new Rect (25, Screen.height - 40, 100, 30), pname);
			if (GUI.Button (new Rect (130, Screen.height - 40, 80, 30), "Change")) {
				CmdChangeName (pname);
			}
		}
	}


	[Command]
	public void CmdChangeName(string newName){
		pname = newName;
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

	// Use this for initialization
	void Start () 
	{
		source = this.GetComponent<AudioSource> ();

		if (isLocalPlayer)
			GetComponent <drive>().enabled = true;
		    //GetComponent<view> ().enabled = false;
		    GetComponent <FacinCamera>().enabled = true;
	}
	
	void Update()
	{ 
		//if (isLocalPlayer) 加上这句，则只改变本地值
			this.GetComponentInChildren<TextMesh>().text = pname;
		/*if(isActive)

		*/
	
	}


}