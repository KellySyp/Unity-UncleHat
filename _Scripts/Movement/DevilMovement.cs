using UnityEngine;
using System.Collections;

public class DevilMovement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;

	public int speed = 1;

	private int walkTimeMin = 5;
	private int walkTimeMax = 10;
	private int waitTimeMin = 10;
	private int waitTimeMax = 20;
	private float newWaitTime = 0.0f;

	public bool thisCanMove = true;
	private bool isWaiting = true;
	private Vector3 newDirection;
	private float newWalkTime = 0.0f;


	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (thisCanMove) {
				if (!isWaiting) {
					if (newWalkTime <= 0) {
						randomDirection ();
					} else {
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
	}

	void randomDirection(){
		isWaiting = !isWaiting;
		if (isWaiting) {
			anim.SetBool ("isWalking", false);
			newWaitTime = Random.Range (waitTimeMin, waitTimeMax);
		} else {
			anim.SetBool ("isWalking", true);
			newDirection = new Vector3 (Random.Range (-1.0f, 1.0f), 0.0f,0.0f);
			newWalkTime = Random.Range (walkTimeMin, walkTimeMax);
			anim.SetFloat ("Input_x", newDirection.x);
		}
	}
}
