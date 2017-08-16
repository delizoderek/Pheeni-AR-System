using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLine {

	private Vector3 start;
	private Vector3 end;
	private Material lineMat;
	private LineRenderer line;
	private float slope;
	private float lineWidth = 1f;
	private string name = "NewLine";
	private ArrayList<GameObject> points = new ArrayList<GameObject>();

	public DLine(){
		line = new GameObject (name).AddComponent<LineRenderer> ();
		line.positionCount = 2;
		line.startWidth = lineWidth;
		line.endWidth = lineWidth;
		line.useWorldSpace = true;
	}

	public DLine(Vector3 startPoint, Vector3 endPoint){
		line = new GameObject (name).AddComponent<LineRenderer> ();
		line.positionCount = 2;
		line.startWidth = lineWidth;
		line.endWidth = lineWidth;
		line.useWorldSpace = true;
		line.SetPosition (0, startPoint);
		line.SetPosition (2, endPoint);
	}

	public DLine(Vector3 startPoint, Vector3 endPoint, Material mat){
		line = new GameObject (name).AddComponent<LineRenderer> ();
		lineMat = mat;
		line.material = mat;
		line.positionCount = 2;
		line.startWidth = lineWidth;
		line.endWidth = lineWidth;
		line.useWorldSpace = true;
		line.SetPosition (0, startPoint);
		line.SetPosition (1, endPoint);
	}

	public DLine(Vector3 startPoint, Vector3 endPoint, Material mat,string newName){
		line = new GameObject(newName).AddComponent<LineRenderer> ();
		lineMat = mat;
		line.material = mat;
		line.positionCount = 2;
		line.startWidth = lineWidth;
		line.endWidth = lineWidth;
		line.useWorldSpace = true;
		line.SetPosition (0, startPoint);
		line.SetPosition (1, endPoint);
		orbs (startPoint, endPoint).transform.parent = line.gameObject.transform;
	}

	public void setStart(Vector3 newStart){
		start = newStart;
		line.SetPosition (0, newStart);
	}

	public void setEnd(Vector3 newEnd){
		end = newEnd;
		line.SetPosition (1, newEnd);
	}

	public void setMaterial(Material mat){
		lineMat = mat;
	}

	public Material getMaterial(){
		return lineMat;
	}

	public Vector3 getStart(){
		return start;
	}

	public Vector3 getEnd(){
		return end;
	}

	public string getName(){
		return name;
	}

	public void updateOrbPos(Vector3 newStart, Vector3 newEnd){
		Vector3 newPos = (newEnd - newStart) / (newEnd - newStart).magnitude;
		float distance = (newEnd - newStart).magnitude;
		newPos *= distance / 6f;
		for (int i = 0; i < points.size (); i++) {
			points.get (i).transform.position = newStart + (newPos * (i + 1));
		}
	}

	public void lineVisibility(bool active){
		line.gameObject.SetActive (active);
	}

	public void hideLine(){
		line.gameObject.SetActive (false);
	}

	public void setParent(Transform parental){
		line.gameObject.transform.parent = parental;
	}

	public GameObject orbs(Vector3 start, Vector3 end){
		Vector3 starting = (end - start)/(end - start).magnitude;
		float distance = (end - start).magnitude;
		starting *= distance / 6;
		GameObject holder = new GameObject ("holder");
		holder.transform.position = start;
		for (int i = 1; i < 6; i++) {
			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			sphere.GetComponent<SphereCollider> ().isTrigger = true;
			sphere.AddComponent<OrbDestruction> ();
			sphere.transform.localScale = new Vector3 (3f, 3f, 3f);
			sphere.transform.position = start + (starting * i);
			sphere.transform.parent = holder.transform;
			points.insert (sphere);
		}
		return holder;
	}
}
