using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

	public string Name;
	public bool moveRandom;
	public string scriptName;
	public bool diaRandom;
	public bool diaDevil;

	// Use this for initialization
	void Awake () {
		int moveMode = 0;
		if (moveRandom) {
			moveMode = 1;
		}

		int diaType = 0;
		if (diaRandom) {
			diaType = 1;
		}if (diaDevil) {
			diaType = 2;
		}

		NPC thisNPC = new NPC (Name, moveMode, scriptName, diaType);

		GameController.NPCManager [Name] = thisNPC;
	
	}

}
