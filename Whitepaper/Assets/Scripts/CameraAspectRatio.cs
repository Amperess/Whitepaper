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

        Camera camera = GetComponent<Camera>();

        RectTransform test_page = pages[0].GetComponent<RectTransform>();
        Rect test_page_dim = test_page.rect;

        // Rect temp = camera.rect;

        // //temp.position = new Vector2(test_page_dim.x, test_page_dim.y);
        // temp.x = test_page_dim.x;
        // temp.y = test_page_dim.y;

        // camera.rect = temp;

        //camera.transform.position = pages[0].transform.position;
        pages[0].transform.position = new Vector2(0, 0);
        test_page.position = new Vector2(0, 0);


        Debug.Log(test_page_dim.x + " " + test_page_dim.y + " " + test_page_dim.width + " " + test_page_dim.height);

        Debug.Log(Screen.width + " " + Screen.height);

        Debug.Log(camera.rect.x + " " + camera.rect.y + " " + camera.rect.width + " " + camera.rect.height);

        float page_ratio = test_page_dim.width / test_page_dim.height;

        float window_ratio = (float) Screen.width / (float) Screen.height;

        float scaleheight = window_ratio / page_ratio;

        // Rect rect = camera.rect;
        // rect.x = test_page_dim.x;
        // rect.y = test_page_dim.y;
        // rect.height = scaleheight;
        // //rect.width = Screen.width;
        // rect.width = 1.0f / page_ratio;
        // camera.rect = rect;

        // Debug.Log(camera.rect.x + " " + test_page_dim.x);

        // I.E., the page's width is bigger than the screen's width
        if (page_ratio > window_ratio) {
            //
        }
        else {

        }

        // float targetaspect = 16.0f / 9.0f;

        // float windowaspect = (float) Screen.width / (float) Screen.height;


        // float scaleheight = windowaspect / targetaspect;
        
        // Camera camera = GetComponent<Camera>();

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
