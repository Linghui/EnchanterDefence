﻿using UnityEngine;
using System.Collections;

public class LightingController : MonoBehaviour {
	

	public float deadDelay = 0.2f;
	void Start ()
	{
		Destroy (gameObject, deadDelay);

	}

	void Update(){

	}
}
