using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectTouch : MonoBehaviour {
	public SpriteRenderer popup_sr;
	public SpriteRenderer gray_sr;
	// Use this for initialization
	void Start () {
		popup_sr = GameObject.Find("popup").GetComponent<SpriteRenderer>();
		gray_sr = GameObject.Find("gray").GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			if(popup_sr.sortingOrder == 1){
				popup_sr.sortingOrder = -1;
				gray_sr.sortingOrder = -1;
			}else{
				Debug.Log(Input.touchCount);
				Debug.Log("Touching " + Input.touches[0].position);
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);
				if(hit.collider != null && hit.collider.name != null){
					Debug.Log("I hit something!");
					if(popup_sr.sortingOrder == -1){
						popup_sr.sortingOrder = 1;
						gray_sr.sortingOrder = 0;
					}
				}
			}
		}
	}
}
