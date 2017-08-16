using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour {

	public Material lineMat;

	private GameController controller;
	private bool pathCreated;
	private GameObject[] pattern;
	private DLine[] lines;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("GameController").GetComponent<GameController>();
		pattern = controller.getPattern ();
		lines = new DLine[pattern.Length - 1];
		pathCreated = false;
		GeneratePath ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pathCreated) {
			updatePath ();
		}
	}

	public void GeneratePath(){
		for (int i = 0; i < pattern.Length - 1; i++) {
			lines[i] = new DLine (pattern[i].transform.position,pattern[i + 1].transform.position,lineMat,"line " + i);
			lines [i].setParent (pattern [i].transform);
		}
		pathCreated = true;
	}

	private void updatePath(){
		for (int i = 0; i <  pattern.Length - 1; i++) {
			lines [i].setStart (pattern [i].transform.position);
			lines [i].setEnd (pattern[i + 1].transform.position);
			lines [i].updateOrbPos (pattern [i].transform.position, pattern [i + 1].transform.position);
		}
	}
}
