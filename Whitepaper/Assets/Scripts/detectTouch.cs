using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Debug.Log(Input.touchCount);
			Debug.Log("Touching " + Input.touches[0].position);
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);
			if(hit.collider != null && hit.collider.name != null){
				Debug.Log("I hit something!");
			}
		}
	}
}
