using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	public string name;
	public int moveType;
	public string diaScript;
	public int diaType;

	public bool canMove;
	public bool inDialogue;
	public int diaCounter;
	public string label;

	public NPC(string newName, int newMoveType, string newScript, int newDiaType){

		name = newName;
		moveType = newMoveType;
		diaScript = newScript;
		diaType = newDiaType;

		canMove = true;
		inDialogue = false;
		diaCounter = 0;
		label = "";

	}
}
