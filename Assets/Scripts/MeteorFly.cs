﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFly : MonoBehaviour {

	
	Rigidbody rgb;
	public float speed = 0.0f;
	public float maxSpeed = 40.0f;
	void Start () {
		rgb = GetComponent<Rigidbody>();
		speed = Random.Range(5.0f, maxSpeed);
		rgb.velocity += new Vector3(0.0f, 0.0f, -speed);
	}
	
	void Update () {
		rgb.velocity = new Vector3(0.0f, 0.0f, Mathf.Clamp(rgb.velocity.z, -maxSpeed * 2, -3.0f));
	}



	
}