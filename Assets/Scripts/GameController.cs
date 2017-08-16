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

	private LightPulse source;
	string[] pattern = {"Tag 1","Tag 2","Tag 4","Tag 3","Tag 1"};
	//string[] pattern = {"Stamp 1","Stamp 2","Stamp 3","Stamp 4","Stamp 1"};
	string[] pattern1 = {"Tag 2","Tag 4","Tag 1"};
	string[] pattern2 = {"Tag 3","Tag 4","Tag 2"};
	string[] pattern3 = {"Tag 2","Tag 4","Tag 3","Tag 1"};
	string[] instructions = { "", "r,90", "r,90", "r,90" };
	int step;

	RaycastHit tagCheck;
	Vector3 central = new Vector3 (0, 0.5f, 0);
	GameObject nextTag;
	LineRenderer line;


	// Use this for initialization
	void Start () {
		step = 0;
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
			if(step >= targetList.Length){
				step = 0;
			}
		}
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

	public void stop(){
		step++;
	}

	public void clickToMove(){
		if (instructions [step].Contains ("r")) {
			string cmd = instructions [step].Split (',')[1];
			float degrees = float.Parse(cmd);
			player.transform.Rotate (new Vector3 (0, degrees, 0));
		}
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
			gamePattern[i] = targetList[findTagIndex(pattern[i])];
		}
		return gamePattern;
	}
}
