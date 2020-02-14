using UnityEngine;
using System.Collections;

public class Wrench : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (!GameController.onQuad && col.gameObject.tag == "Player") {
			GameController.hasWrench = true;
			Destroy (gameObject);
		}

	}
}
