/*
 * Created By Derek DeLizo
 * A generic Array List class to store objects
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayList<T>{
	private int numElements;
	private T[] data;

	public ArrayList(){
		numElements = 0;
		data = new T[50];
	}

	public ArrayList(ArrayList<T> a){
		for (int i = 0; i < a.size (); i++) {
			data [i] = a.get (i);
		}
		numElements = data.Length;
	}

	public ArrayList(T[] a){
		for (int i = 0; i < a.Length ; i++) {
			data [i] = a[i];
		}
		numElements = data.Length;
	}

	public int size(){
		return numElements;
	}

	public void insert(T obj){
		if (numElements == data.Length) {
			resize ();
		}
		data [numElements++] = obj;
	}

	public T remove(int index){
		T obj = data [index];
		data [index] = default(T);
		numElements--;
		return obj;
	}

	public T get(int index){
		return data [index];
	}

	public int indexOf(T obj){
		int index = -1;
		for (int i = 0; i < numElements; i++) {
			if (obj.Equals (data [i])) {
				index = i;
				break;
			}
		}
		return index;
	}

	public bool isEmpty(){
		return numElements == 0;
	}

	private void resize(){
		T[] temp = new T[data.Length * 2];
		for (int i = 0; i < data.Length; i++) {
			temp [i] = data [i];
		}

		data = temp;
	}
}
