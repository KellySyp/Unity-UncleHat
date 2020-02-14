using UnityEngine;
using System.Collections;

public class dismountQuad : MonoBehaviour {

	public GameObject Quad;
	public GameObject Player;
	public GameObject RidingQuad;

	public int PlayerOffset = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.onQuad && Input.GetKeyDown ("space")) {
			GameController.onQuad = false;
			Quad.transform.position = RidingQuad.transform.position;
			Player.transform.position = new Vector3 (RidingQuad.transform.position.x + PlayerOffset, 
					RidingQuad.transform.position.y, 
					RidingQuad.transform.position.z);
			Player.SetActive (true);
			Quad.SetActive (true);
			RidingQuad.SetActive (false);
		}
	
	}
}
