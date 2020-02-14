using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//A basic dialogue system
public class SimpleDialogue : MonoBehaviour {

	private GameObject DialogueObj;
	public string filename = "test";

	private bool listenKey = false;
	private bool inDialogue = false;
	//private int dialogueCounter = 0;

	void Start(){
		DialogueObj = GameObject.FindGameObjectWithTag ("DiaObj");
	}

	//When this function is triggered....
	void Update(){
		if (listenKey && Input.GetKeyDown ("space")) {
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
		if (!inDialogue) {
			inDialogue = true;
			DialogueObj.transform.Find ("DialogueController").GetComponent<DialogueController> ().setDialogue (filename);
			//this.transform.parent.GetComponent<NPC_Movement> ().thisCanMove = false;
		}
		DialogueObj.transform.Find ("DialogueController").GetComponent<DialogueController> ().advanceDialogue ();
	}
}
