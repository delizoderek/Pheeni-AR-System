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
	private ArrayList<Vector3> points = new ArrayList<Vector3>();

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
		//Vector3[] sphereLocations = calculateSpawnLoc (startPoint,endPoint);
		GameObject newLine = new GameObject (newName);

		name = newName;
		newLine.transform.position = startPoint;
		for (int i = 0; i < 4; i++) {
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.name = (newName + "Sphere" + i);
			sphere.AddComponent<SphereCollider> ();
			sphere.transform.parent = newLine.transform;
			sphere.transform.position = new Vector3 (startPoint.x + (i * 5),0,startPoint.y);
		}
		line = newLine.AddComponent<LineRenderer> ();
		lineMat = mat;
		line.material = mat;
		line.positionCount = 2;
		line.startWidth = lineWidth;
		line.endWidth = lineWidth;
		line.useWorldSpace = true;
		line.SetPosition (0, startPoint);
		line.SetPosition (1, endPoint);
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

	private void getPoints(Vector3 start, Vector3 end){
		Vector3 midpoint = (end - start) / 2.0f;
		Vector3 startCopy = start;
		Vector3 endCopy = end;
		int depth = 2;
		points.insert (midpoint);
		endCopy = midpoint;
		midpoint = (midpoint - start) / 2.0f;
		points.insert (midpoint);
		Vector3 midpointLeft = (midpoint - endCopy) / 2.0f;
		Vector3 midpointRight = (startCopy - midpoint) / 2.0f;
		points.insert (midpointLeft);
		points.insert (midpointRight);
	}

	private void getPoints(Vector3 start, Vector3 end,int depth){
		Vector3 midpoint = (end - start) / 2.0f;
		Debug.Log (depth);
		if (depth > 0) {
			depth--;
			getPoints (start, midpoint,depth);
			getPoints (midpoint, start,depth);
		} else {
			points.insert (midpoint);
		}
	}
}
