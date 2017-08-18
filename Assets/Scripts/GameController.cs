using Vuforia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

	public LayerMask tag;
	public Material lineMat;
	public GameObject player;
	public GameObject[] targetList;
	public Dropdown menu;
	public Text scoreBox;
	public Text nextCheck;

	private LightPulse source;
	private int score;

	string[] pattern = {"Tag 1","Tag 2","Tag 3","Tag 4","Tag 1"};
	//string[] pattern = {"Stamp 1","Stamp 2","Stamp 3","Stamp 4","Stamp 1"};
	string[] pattern1 = {"Tag 2","Tag 4","Tag 1"};
	string[] pattern2 = {"Tag 3","Tag 4","Tag 2"};
	string[] pattern3 = {"Tag 1","Tag 2","Tag 3","Tag ","Tag 1"};
	int step;

	RaycastHit tagCheck;
	GameObject nextTag;
	LineRenderer line;


	// Use this for initialization
	void Start () {
		step = 0;
		score = 0;
		scoreBox.text = "Score: " + score;
		nextCheck.text = "Next Tag: " + pattern [0];
	}
	
	// Update is called once per frame
	void Update () {
		nextTag = targetList[findTagIndex(pattern[step])];
		if (nextTag.GetComponent<TagController> ().isPulsing () == false) {
			nextTag.GetComponent<TagController> ().enablePulse ();
		}

		if (nextTag.GetComponent<TagController>().objectArrival()) {
			nextTag.GetComponent<TagController> ().disablePulse ();
			step++;
			nextCheck.text = "Next Tag: " + pattern [step];
			if(step >= targetList.Length){
				step = 0;
			}
		}



	}

	public void UpdateScore(){
		++score;
		scoreBox.text = "Score: " + score;
	}

	int findTagIndex(string t){
		int retVal = -1;
		for (int i = 0; i < targetList.Length; i++) {
			if (targetList [i].name.Equals (t)) {
				retVal = i;
				break;
			}
		}
		return retVal;
	}

	public string playerName(){
		return player.name;
	}

	public bool patternReady(){
		bool allDetected = true;
		for (int i = 0; i < pattern.Length - 1; i++) {
			TrackableBehaviour tb = targetList [i].GetComponent<TrackableBehaviour> ();
			if (tb.CurrentStatus == TrackableBehaviour.Status.NOT_FOUND) {
				allDetected = false;
				break;
			}
		}
		return allDetected;
	}

	public void stop(){
		step++;
	}

	public void valueChange(){
		int selection = menu.value;
		switch (selection) {
		case 0:
			//Pattern 1
			break;
		case 1:
			//Pattern 2
			break;
		case 2:
			//Pattern 3
			break;
		}
	}

	public GameObject[] getPattern(){
		GameObject[] gamePattern = new GameObject[pattern.Length];
		for (int i = 0; i < pattern.Length; i++) {
			gamePattern[i] = targetList[findTagIndex(pattern[i])].GetComponent<TagController>().linePoint;
		}
		return gamePattern;
	}
}
