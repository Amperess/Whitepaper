using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour {

	public bool clicked;
	public float zoomInFOV;
	public float orthoFinal;
	public float smooth;


	void Start () {
		clicked = false;
		zoomInFOV = 2;
		smooth = 10;
		orthoFinal = 1;
	}

	void Update () {
		if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) {
			clicked = true;
		}

		if (clicked) {
			ChangeFOV();
		}

	}

	void ChangeFOV() {
		float currentFOV = Camera.main.fieldOfView;
		float currentOrtho = Camera.main.orthographicSize;
        if (currentFOV != zoomInFOV || currentOrtho != orthoFinal) {
			if (currentFOV > zoomInFOV) {
				 Camera.main.fieldOfView -= (smooth * Time.deltaTime);
			}
			else {
				if (currentFOV >= zoomInFOV) {
					Camera.main.fieldOfView = zoomInFOV;
				}
            }

            if (currentOrtho > orthoFinal) {
            	Camera.main.orthographicSize -= (smooth * Time.deltaTime);
            }
            else {
				if (currentOrtho >= orthoFinal) {
					Camera.main.orthographicSize = orthoFinal;
				}
            }
        }
	}
}
