using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDestruction : MonoBehaviour {
	public GameController control;    //Will be used when points are implemented

	void OnTriggerEnter (Collider col){
		Destroy (gameObject);
	}
}
