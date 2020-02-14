using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rbody;
	Animator anim;
	public int speed = 1;

	public float minX = 0.0f;
	public float maxX = 10.0f;

	public AudioClip quadIdling;
	public AudioClip quadRevving;

	public static bool canMove = true; 

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

			if (movement_vector != Vector2.zero) {
				anim.SetBool ("isWalking", true);
				anim.SetFloat ("Input_x", movement_vector.x);
				anim.SetFloat ("Input_y", movement_vector.y);
			} else {
				anim.SetBool ("isWalking", false);
			}

			Mathf.Clamp (rbody.transform.position.x, minX, maxX);


			rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * speed);

		if (GameController.onQuad && (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0)) {
				if (gameObject.GetComponent<AudioSource> ().clip != quadRevving) {
					gameObject.GetComponent<AudioSource> ().clip = quadRevving;
					gameObject.GetComponent<AudioSource> ().Play ();
				}
			} else if (GameController.onQuad) {
				if (gameObject.GetComponent<AudioSource> ().clip != quadIdling) {
					gameObject.GetComponent<AudioSource> ().clip = quadIdling;
					gameObject.GetComponent<AudioSource> ().Play ();
				}
			}
		} else {
			anim.SetBool ("isWalking", false);
		}
	}
}
