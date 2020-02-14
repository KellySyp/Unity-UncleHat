using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;

	public int speed = 1;
	private int mode = 0;
	private string name;

	private int walkTimeMin = 10;
	private int walkTimeMax = 20;
	private int waitTimeMin = 5;
	private int waitTimeMax = 10;
	private float newWaitTime = 0.0f;

	public bool thisCanMove = true;
	private bool isWaiting = true;
	private Vector3 newDirection;
	private float newWalkTime = 0.0f;


	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		name = GetComponent<NPCController> ().Name;
		mode = GameController.NPCManager [name].moveType;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.NPCManager [name].canMove) {
			if (mode > 0) {
				if (!isWaiting) {
					if (newWalkTime <= 0) {
						randomDirection ();
					} else {
						anim.SetBool ("isWalking", true);
						rbody.MovePosition (rbody.transform.position + newDirection * Time.deltaTime * speed);
						newWalkTime -= Time.deltaTime;
					}
				} else {
					if (newWaitTime <= 0) {
						randomDirection ();
					} else {
						newWaitTime -= Time.deltaTime;
					}

				}
			}
		} else {
			anim.SetBool ("isWalking", false);
		}
	}

	void randomDirection(){
		isWaiting = !isWaiting;
		if (isWaiting) {
			anim.SetBool ("isWalking", false);
			newWaitTime = Random.Range (waitTimeMin, waitTimeMax);
		} else {
			anim.SetBool ("isWalking", true);
			newDirection = new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f),0.0f);
			newWalkTime = Random.Range (walkTimeMin, walkTimeMax);
			anim.SetFloat ("Input_x", newDirection.x);
			anim.SetFloat ("Input_y", newDirection.y);
		}
	}
}
