using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagController : MonoBehaviour {

	public GameObject currentTag;
	public GameObject source;
	bool inRange = false;

	private GameObject pheeni;
	private bool active;
	private bool hasArrived;
	private bool player;

	RaycastHit pheeniFinder;

	// Use this for initialization
	void Start () {
		BoxCollider collider = gameObject.AddComponent<BoxCollider> ();
		Vector3 colliderCenter = new Vector3 (0, 0, -0.25f);
		Vector3 colliderSize = new Vector3 (10f, 8f, 10f);
		collider.center = colliderCenter;
		collider.size = colliderSize;
		collider.isTrigger = true;

		active = false;
		hasArrived = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name.Equals ("Sphere")) {
			hasArrived = true;
		}
	}

	void OnTriggerExit(Collider col){
		hasArrived = false;
	}

	public void setRange(){
		inRange = true;
	}

	public void enablePulse(){
		active = true;
		source.SetActive (true);
	}

	public void disablePulse(){
		active = false;
		source.SetActive (false);
	}

	public bool isPulsing(){
		return active;
	}

	public bool objectArrival(){
		return hasArrived;
	}
}
