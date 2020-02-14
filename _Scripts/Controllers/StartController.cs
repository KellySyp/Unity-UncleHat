using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pressStart(){
		SceneManager.LoadScene ("Main", LoadSceneMode.Single);
		GameController.onQuad = false;
		GameController.piecesWood = 0;
		GameController.hasWrench = false;
		GameController.seenDevil = false;
		PlayerMovement.canMove = true;
		foreach (var thisNPC in GameController.NPCManager.Keys) {
			GameController.NPCManager [thisNPC].canMove = true;
		}
	}

	public void pressRestart(){
		SceneManager.LoadScene ("Start", LoadSceneMode.Single);

	}
}
