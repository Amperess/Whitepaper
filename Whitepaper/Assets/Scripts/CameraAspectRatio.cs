using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // rect.height = height of page asset
        // rect.x = top left corner of page x position
        // rect.y = top left corner of page y position
        // rect.width = Screen.width
        GameObject[] pages = GameObject.FindGameObjectsWithTag("TestPage");

        //RectTransform test_page = pages[0].transform as RectTransform;

        Debug.Log(pages[0].transform);
        //Debug.Log(pages[0].transform.parent);

        //Bounds test_page_dim = pages[0].GetComponent<Bounds>();

        //Debug.Log(test_page_dim);

        float targetaspect = 16.0f / 9.0f;

        float windowaspect = (float) Screen.width / (float) Screen.height;

        Debug.Log(Screen.width + " " + Screen.height);

        float scaleheight = windowaspect / targetaspect;
        
        Camera camera = GetComponent<Camera>();

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
