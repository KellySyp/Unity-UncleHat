using UnityEngine;
using System.Collections;

public class Devil : MonoBehaviour {

	private bool listenFlag = false;
	private AudioSource audio;

	private bool fadeout = false;
	private float alpha = 1.0f;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (listenFlag && Input.GetKeyDown ("space")) {
			GameController.seenDevil = true;
			StartCoroutine (killDevil ());
		}
		GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, alpha);

		if (fadeout) {
			alpha = alpha - 0.01f;
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" && !GameController.onQuad) {
			listenFlag = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player" && !GameController.onQuad) {
			listenFlag = false;
		}
	}

	IEnumerator killDevil(){
		audio.Play ();
		GetComponent<DevilMovement> ().thisCanMove = false;
		fadeout = true;
		GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, .5f);
		yield return new WaitForSeconds (2.0f);
		Destroy (gameObject);
	}
}
