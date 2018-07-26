using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {

	public bool clicked;
	public float zoomOutFOV;
	public float orthoFinal;
	public float smooth;


	void Start () {
		clicked = false;
		zoomOutFOV = 125;
		smooth = 10;
		orthoFinal = 20;
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
        if (currentFOV != zoomOutFOV || currentOrtho != orthoFinal) {
			if (currentFOV < zoomOutFOV) {
				 Camera.main.fieldOfView += (smooth * Time.deltaTime);
			}
			else {
				if (currentFOV <= zoomOutFOV) {
					Camera.main.fieldOfView = zoomOutFOV;
				}
            }

            if (currentOrtho < orthoFinal) {
            	Camera.main.orthographicSize += (smooth * Time.deltaTime);
            }
            else {
				if (currentOrtho <= orthoFinal) {
					Camera.main.orthographicSize = orthoFinal;
				}
            }
        }
	}
}
