using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagController : MonoBehaviour {

	public GameObject currentTag;
	public GameObject linePoint;
	public GameObject source;

	private GameObject pheeni;
	private bool active;
	private bool hasArrived;
	private bool player;

	RaycastHit pheeniFinder;

	// Use this for initialization
	void Start () {
		BoxCollider collider = gameObject.AddComponent<BoxCollider> ();
		Vector3 colliderCenter = currentTag.gameObject.transform.position;
		Vector3 colliderSize = new Vector3 (1f, 2f, 1f);
		collider.center = transform.InverseTransformPoint(colliderCenter);
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
