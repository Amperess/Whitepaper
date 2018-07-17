using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] pages = GameObject.FindGameObjectsWithTag("TestPage");

        Camera camera = GetComponent<Camera>();

        RectTransform test_page = pages[0].GetComponent<RectTransform>();
        Rect test_page_dim = test_page.rect;

        pages[0].transform.position = new Vector2(0, 0);
        test_page.position = new Vector2(0, 0);

        float page_ratio = (test_page_dim.width / test_page_dim.height);

        float window_ratio = (float) Screen.width / (float) Screen.height;

        Camera.main.orthographicSize = (test_page_dim.height / 2.0f) * page_ratio;
        Camera.main.aspect = window_ratio;

        Debug.Log(test_page.localScale);
        //x * test_page.height = Screen.height;
        Debug.Log(page_ratio / window_ratio);
        test_page.localScale = new Vector3(1.0f, page_ratio/window_ratio, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
