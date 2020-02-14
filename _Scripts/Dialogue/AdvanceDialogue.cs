using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//A basic dialogue system
public class AdvanceDialogue : MonoBehaviour {

	private GameObject DialogueObj;

	private bool listenKey = false;
	private bool inDialogue = false;
	//private int dialogueCounter = 0;

	private string NPCName;

	public bool repeatLast = false;
	public bool randomDialogue = false;

	void Start(){
		NPCName = GetComponentInParent<NPCController> ().Name;
		DialogueObj = GameObject.FindGameObjectWithTag ("DiaObj");

	}

	//When this function is triggered....
	void Update(){
		if (listenKey && Input.GetKeyDown ("space") && !GameController.quadTarget) {
			ActionBtnClicked ();
		}
	}

	//When the player enter's the object's field, the action button clears out previous actions and sets up action button
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			listenKey = true;
		}
	}

	//When Player leaves obect's field, action panel disappears
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			listenKey = false;
		}
	}



	//We hide the action panel, send the script file to the manager, then start the dialogue.
	void ActionBtnClicked(){
		GameController.NPCManager [NPCName].canMove = false;
		GameController.targetNPC = GetComponentInParent<NPCController> ().Name;
		if (!GameController.NPCManager[NPCName].inDialogue) {
			GameController.NPCManager[NPCName].inDialogue = true;
			DialogueObj.transform.Find ("DialogueController").GetComponent<DialogueController> ().setDialogue (GameController.NPCManager[NPCName].diaScript);
			DialogueObj.transform.Find ("DialogueController").GetComponent<DialogueController> ().setType (GameController.NPCManager[NPCName].diaType);
			DialogueObj.transform.Find ("DialogueController").GetComponent<DialogueController> ().label  = GameController.NPCManager[NPCName].label;
			DialogueObj.transform.Find ("DialogueController").GetComponent<DialogueController> ().dialogueCounter = GameController.NPCManager[NPCName].diaCounter;
		}
		DialogueObj.transform.Find ("DialogueController").GetComponent<DialogueController> ().advanceDialogue ();
		GameController.NPCManager [NPCName].label = DialogueObj.transform.Find ("DialogueController").GetComponent<DialogueController> ().label;
		GameController.NPCManager [NPCName].diaCounter = DialogueObj.transform.Find ("DialogueController").GetComponent<DialogueController> ().dialogueCounter;
	}



}
