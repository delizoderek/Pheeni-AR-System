using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour {

	Light source;
	bool glowing ;
	bool glow;

	// Use this for initialization
	void Start () {
		source = GetComponent<Light> ();
		glowing = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (source.range >= 25) {
			glowing = false;
		} else if (source.range <= 15) {
			glowing = true;
		}

		if (glowing) {
			source.range += 0.1f;
		} else {
			source.range -= 0.1f;
		}
	}
}
