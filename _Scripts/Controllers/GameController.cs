using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class GameController : MonoBehaviour {

	public int setHour = 10;
	public int setMinute = 00;
	public int endHour = 5;

	public static bool onQuad = false;
	public static bool quadTarget = false;

	private static bool advanceTime = true;
	public static int hour;
	public static int minute;
	private string txtHour;
	private string txtMinute;

	public static int piecesWood = 0;
	public static bool hasWrench = false;
	public static bool seenDevil = false;

	UnityEngine.UI.Text timeHUD;
	GameObject woodHUDImage;
	UnityEngine.UI.Text woodHUD;
	GameObject wrenchHUD;
	GameObject devilHUD;

	private AudioSource audio;
	public AudioClip clip;
	private bool fadeout = false;
	private float alpha = 0.0f;
	public GameObject fader;

	public static Dictionary<string, NPC> NPCManager = new Dictionary<string, NPC> ();
	public static string targetNPC = "";
	public static bool playerInDialogue;

	void Awake(){
		timeHUD = GameObject.Find ("TimeHUD").GetComponent<Text> ();
		woodHUD = GameObject.Find ("WoodHUD").GetComponent<Text> ();
		devilHUD = GameObject.Find ("DevilHUD");
		wrenchHUD = GameObject.Find ("WrenchHUD");
		woodHUDImage = GameObject.Find ("WoodImage");
	}
	// Use this for initialization
	void Start () {
		fader.SetActive (false);
		InvokeRepeating("timeForward", 1.0f, 1.0f);
		hour = setHour;
		minute = setMinute;
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (fadeout) {
			fader.SetActive(true);
			alpha = alpha + 0.01f;
			fader.GetComponent<Image> ().color = new Color (0f, 0f, 0f, alpha);
		}

		txtHour = hour.ToString();
		txtMinute = minute.ToString();
		if (minute < 10){
			txtMinute = "0" + minute;
		}
		timeHUD.text = txtHour + ":" + txtMinute;
		if (piecesWood > 0) {
			woodHUDImage.SetActive (true);
			woodHUD.text = "x" + piecesWood;
		} else {
			woodHUDImage.SetActive (false);
			woodHUD.text = "";
		}
		if (hasWrench) {
			wrenchHUD.SetActive (true);
		} else {
			wrenchHUD.SetActive (false);
		}
		if (seenDevil) {
			devilHUD.SetActive (true);
		} else {
			devilHUD.SetActive (false);
		}
	}

	void timeForward(){
		if (advanceTime) {
			minute++;
			if (minute == 60) {
				hour++;
				minute = 0;
			}
			if (hour == 13) {
				hour = 1;
			}
			//Game Over
			if (hour == endHour) {
				StartCoroutine (gameOver());

			}
		}
	}

	IEnumerator gameOver(){
		audio.PlayOneShot(clip);
		PlayerMovement.canMove = false;

		foreach (var thisNPC in NPCManager.Keys) {
			NPCManager [thisNPC].canMove = false;
		}
		yield return new WaitForSeconds (2.0f);
		fadeout = true;
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Start", LoadSceneMode.Single);
	}
}
