﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			while (Camera.main.fieldOfView <=125 || Camera.main.orthographicSize <=20) {
				Camera.main.fieldOfView += 2;
				Camera.main.orthographicSize += 0.5;
			}
		}
	}
}
