﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Na przyszlosc zrobic z tego statica wzorzec singleton

 */
public class Kursor3D : MonoBehaviour {

	Vector3 position;

	public Material Clicked;
	public Material NonClicked;
	//public GameObject block;
	//HingeJoint test;
	//Rigidbody rgb;

	bool isClicked;
	bool isPressed;
	Collider obj;
	Vector3 lastPosition;
	public Vector3 delta;
	
	float t;
	void Start () {
		t = 0.1f;
		position = new Vector3(0.0f, 0.0f, 0.0f);
		isClicked = false;
		lastPosition = position;
		obj = null;
		isPressed = false;
		//test = block.GetComponent<HingeJoint>();
		//rgb = GetComponent<Rigidbody>();
		//test.connectedBody = rgb;
	}
	
	
	void Update () {
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			position = Vector3.Lerp(position, position + new Vector3(-0.1f, 0.0f, 0.0f),t);
		} if(Input.GetKey(KeyCode.RightArrow)){
			position = Vector3.Lerp(position,position + new Vector3(0.1f, 0.0f, 0.0f),t);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, 0.0f, -0.1f),t);
		} if(Input.GetKey(KeyCode.UpArrow)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, 0.0f, 0.1f),t);
		}

		if(Input.GetKey(KeyCode.Q)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, 0.1f, 0.0f),t);
		} if(Input.GetKey(KeyCode.E)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, -0.1f, 0.0f),t);
		}

		if(Input.GetKey(KeyCode.LeftShift)){ 
			isClicked = !isClicked;
		} 

		if(Input.GetKey(KeyCode.LeftShift)){
			isPressed = true;
		} else {
			isPressed = false;
		}

		if(obj != null){
			obj.transform.position = this.transform.position;
				//obj.transform.position =  Vector3.Lerp(obj.transform.position, (position - lastPosition) + obj.transform.position,1.0f);
			if(obj.GetComponent<HingeJoint>() != null){
					HingeJoint temp = obj.GetComponent<HingeJoint>();
					temp.connectedBody = GetComponent<Rigidbody>();
										temp.connectedAnchor = this.transform.position;
					temp.anchor = this.transform.position;
				}
		}
		delta = lastPosition - position;
		lastPosition = position;

	}

	public Vector3 GetPosition(){
		return position;
	}

	public bool IsPressed(){
		return isPressed;
	}

	
	void OnTriggerEnter(Collider other) {
		
		if(other.tag == "Block"){
			if(isPressed){
				if(other.GetComponent<HingeJoint>() != null){
					HingeJoint temp = other.GetComponent<HingeJoint>();
					temp.connectedBody = GetComponent<Rigidbody>();
					temp.connectedAnchor = this.transform.position;
					temp.anchor = this.transform.position;
				}
				obj = other;
			}
			other.GetComponent<MeshRenderer>().material = Clicked;
		} 
	}



	void OnTriggerExit(Collider other) {
		
		if(other.tag == "Block"){
			//obj = null;
			other.GetComponent<MeshRenderer>().material = NonClicked;
		} 
	}
}
