using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectTouch : MonoBehaviour {
    public SpriteRenderer popup_sr;
    public SpriteRenderer gray_sr;

    // Use this for initialization
    void Start() {
        try {
            //popup_sr = GameObject.Find("popupStacks").GetComponent<SpriteRenderer>();
            //gray_sr = GameObject.Find("gray").GetComponent<SpriteRenderer>();
        }
        catch (Exception e) {
            Debug.Log(e.StackTrace);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount == 1) {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                if (popup_sr.sortingOrder == 4) {
                    popup_sr.sortingOrder = -1;
                    gray_sr.sortingOrder = -1;
                }
                else {
                    Debug.Log(Input.touchCount);
                    Debug.Log("Touching " + Input.touches[0].position);
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);
                    if (hit.collider != null && hit.collider.name != null) {
                        Debug.Log("I hit something!");
                        if (hit.collider.name == "nextPagef") {
                            Debug.Log("Touch is working");
                            // zoom in and out to the next page, or back to page 19 if at the end 
                            if (false) { // page number is currently from 4 to 10 inclusive
                                if (false) { // page number is 10
                                        // go to page 19
                                }
                                else {
                                    // go back to currentPage+1
                                }
                            }
                            else if (false) { // page number is currently from 1 to 2 inclusive
                                if (false) { // page number is 2
                                        // go back to page 19
                                }
                                else {
                                    // go back to currentPage+1
                                }
                            }
                            else if (false) { // page number is currently from 11 to 15 inclusive
                                if (false) { // page number is 15
                                        // go back to page 19
                                }
                                else {
                                    // go back to currentPage+1
                                }
                            }
                        }
                        else if (hit.collider.name == "prevPagef") {
                            // zoom out to the next page, or back to page 19 if at the beginning
                            if (false) { // page number is currently from 4 to 10 inclusive
                                if (false) { // page number is 4
                                        // go back to page 19
                                }
                                else {
                                    // go back to currentPage-1
                                }
                            }
                            else if (false) { // page number is currently from 1 to 2 inclusive
                                if (false) { // page number is 1
                                        // go back to page 19
                                }
                                else {
                                    // go back to currentPage-1
                                }
                            }
                            else if (false) { // page number is currently from 11 to 15 inclusive
                                if (false) { // page number is 11
                                        // go back to page 19
                                }
                                else {
                                    // go back to currentPage-1
                                }
                            }
                        }
                        else {
                            if (hit.collider.name == "19.1") {
                                // zoom in and out to page sequence 1
                                // Change to page 4
                            }
                            else if (hit.collider.name == "19.2") {
                                // zoom in and out to page sequence 2
                                // Change to page 1
                            }
                            else if (hit.collider.name == "19.3") {
                                // zoom in and out to page sequence 3
                                // Change to page 11
                            }
                            else if (hit.collider.name == "19.4") {
                                if (popup_sr.sortingOrder == -1) {
                                    popup_sr.sortingOrder = 4;
                                    gray_sr.sortingOrder = 3;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}