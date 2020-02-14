using UnityEngine;
using System.Collections;

public class mountQuad : MonoBehaviour {

	private bool listenFlag = false;

	public GameObject Quad;
	public GameObject Player;
	public GameObject RidingQuad;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (listenFlag && Input.GetKeyDown("space")) {
			getOnQuad ();
		}

		if (GameController.onQuad && Input.GetKeyUp ("space")) {
			//getOffQuad ();
		}
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			listenFlag = true;
			GameController.quadTarget = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			listenFlag = false;
			GameController.quadTarget = false;
		}
	}

	void getOnQuad(){
		if (!GameController.playerInDialogue) {
			GameController.onQuad = true;
			RidingQuad.transform.position = Quad.transform.position;
			RidingQuad.SetActive (true);
			Player.SetActive (false);
			Quad.SetActive (false);
		}
	}

	void getOffQuad(){
		GameController.onQuad = false;
		Quad.transform.position = RidingQuad.transform.position;
		Player.SetActive (true);
		Quad.SetActive (true);
		RidingQuad.SetActive (false);
	}


}


