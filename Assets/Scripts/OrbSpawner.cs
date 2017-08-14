using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour {
	public GameObject test1;
	public GameObject test2;
	public int numberOfOrbs;
	//private ArrayList
	// Use this for initialization
	void Start () {
		Vector3 starting = (test2.transform.position - test1.transform.position)/(test2.transform.position - test1.transform.position).magnitude;
		float distance = (test2.transform.position - test1.transform.position).magnitude;
		starting *= distance / numberOfOrbs;
		for (int i = 0; i < numberOfOrbs + 1; i++) {
			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			sphere.transform.localScale = new Vector3 (5f, 5f, 5f);
			sphere.transform.position = test1.transform.position + (starting * i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
