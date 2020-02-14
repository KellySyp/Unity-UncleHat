using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		if (GameObject.FindGameObjectsWithTag (gameObject.tag).Length > 1) {
			Destroy (gameObject);
		}
	}

}
