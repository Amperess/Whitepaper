using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			while (Camera.main.fieldOfView>2 || Camera.main.orthographicSize>=1) {
				Camera.main.fieldOfView -= 2;
				Camera.main.orthographicSize -= 0.5;
			}
		}
	}
}
