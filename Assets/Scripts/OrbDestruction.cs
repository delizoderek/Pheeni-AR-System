using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDestruction : MonoBehaviour {
	private GameController control;    //Will be used when points are implemented

	void Start(){
		control = GameObject.Find ("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter (Collider col){
		control.UpdateScore ();
		Destroy (gameObject);
	}
}
