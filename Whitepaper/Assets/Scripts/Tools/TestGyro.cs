using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGyro : MonoBehaviour {

    GameObject cameraParent;

	// Use this for initialization
	void Start () {
        cameraParent = new GameObject("Camera Parent");
        cameraParent.transform.position = this.transform.position;
        this.transform.parent = cameraParent.transform;
        Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        cameraParent.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
	}
}
