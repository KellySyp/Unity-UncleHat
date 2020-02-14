using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CallLibrary : MonoBehaviour {

	public static string thisParameter = "";

	private static bool dictionaryLoaded = false;

	private static AudioSource mySource;


	public static Dictionary<string, System.Action> globalCalls = new Dictionary<string, System.Action> ();
	// Use this for initialization
	void Awake () {
		mySource = GetComponent<AudioSource> ();
		if (!dictionaryLoaded) {
			globalCalls.Add ("testOut", testOut);
			globalCalls.Add ("testParm", testParm);
			globalCalls.Add ("testNumeric", testNumeric);
			globalCalls.Add ("testEndGame", testEndGame);
			globalCalls.Add ("playAudio", playAudio);
			globalCalls.Add ("checkWood", checkWood);
			globalCalls.Add ("checkWrench", checkWrench);
			dictionaryLoaded = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void testOut(){
		Debug.Log ("Test Out");
	}

	public static void testParm(){
		Debug.Log (thisParameter);
	}

	public static void testNumeric(){
		int val = int.Parse (thisParameter);
		Debug.Log(10 * val);
	}

	public static void playAudio(){
		//Create clip
		AudioClip myClip = (AudioClip)Resources.Load(thisParameter);
		mySource.clip = myClip;
		mySource.Play ();
	}

	public static void testEndGame(){
		SceneManager.LoadScene("Over", LoadSceneMode.Single);
	}

	public static void checkWood(){
		if (GameController.piecesWood >= 5) {
			GameController.NPCManager [thisParameter].label = "Found";
		}
	}

	public static void checkWrench(){
		if (GameController.hasWrench) {
			GameController.NPCManager [thisParameter].label = "Found";
		}
	}

}
