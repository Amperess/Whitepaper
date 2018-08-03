using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePage : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	public int pageNumber;
	Vector2 touchOrigin;
	public Sprite[] sprites = new Sprite[28];

	public float zoomInFOV;
	public float orthoInFinal;
	public float zoomOutFOV;
	public float orthoOutFinal;
	public float smooth;

	public float startOrtho;
	public float startFOV;

	public bool hitDetect;
	public int isNext;
	private float elapsed = 0.0f;
	private float duration = 1.0f;

	public SpriteRenderer dark_filter;


	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

		dark_filter = GameObject.Find("dark_filter").GetComponent<SpriteRenderer>();

    	pageNumber = 0;
		loadPages();

		startOrtho = Camera.main.orthographicSize;
		startFOV = Camera.main.fieldOfView;

		zoomOutFOV = 125;
		orthoOutFinal = 20;

		zoomInFOV = 2;
		orthoInFinal = 1;

		smooth = 10;

		hitDetect = false;
		isNext = 0;
	}

	void loadPages () {
		for (int i=0; i<28; i++) {
			sprites[i] = Resources.Load<Sprite>(""+(i+1));
		}
	}

	// Update is called once per frame
	/*
	void Update () {
		if (Input.touchCount > 0)
		{
			//Store the first touch detected.
			Touch myTouch = Input.touches[0];

			//Check if the phase of that touch equals Began
			if (myTouch.phase == TouchPhase.Began)
			{
					//If so, set touchOrigin to the position of that touch
					touchOrigin = myTouch.position;
			}

			//If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
			else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
			{
					//Set touchEnd to equal the position of this touch
					Vector2 touchEnd = myTouch.position;

					//Calculate the difference between the beginning and end of the touch on the x axis.
					float x = touchEnd.x - touchOrigin.x;

					if (x < 0) {
						if(pageNumber < 27) {
							pageNumber++;
							//spriteRenderer.sprite = sprites[pageNumber-1];
							spriteRenderer.sprite = sprites[pageNumber];
						}
					}else if (x > 0) {
						if(pageNumber > 0) {
							pageNumber--;
							spriteRenderer.sprite = sprites[pageNumber];
						}
					}

					//Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
					touchOrigin.x = -1;

			}
		}
	}
	*/
	void Update(){
		if (pageNumber == 24 || pageNumber == 25) {
			dark_filter.sortingOrder = 2;
		}
		else {
			dark_filter.sortingOrder = -1;
		}
		if (hitDetect) { // Perform one iteration of lerp
			if (isNext == 1) { // if nextPagef (zoom in)
				elapsed += Time.deltaTime / duration;
				Camera.main.orthographicSize = Mathf.SmoothStep(startOrtho, orthoInFinal, elapsed);
				Camera.main.fieldOfView = Mathf.SmoothStep(startFOV, zoomInFOV, elapsed);
				if (elapsed > 1.0f) {
					isNext = 3;
					spriteRenderer.sprite = sprites[pageNumber];
					elapsed = 0.0f;
				}
			}
			else if (isNext == 2) { // if prevPagef (zoom out)
				elapsed += Time.deltaTime / duration;
				Camera.main.orthographicSize = Mathf.SmoothStep(startOrtho, orthoOutFinal, elapsed);
				Camera.main.fieldOfView = Mathf.SmoothStep(startFOV, zoomOutFOV, elapsed);
				if (elapsed > 1.0f) {
					isNext = 4;
					spriteRenderer.sprite = sprites[pageNumber];
					elapsed = 0.0f;
				}
			}
			// REVERSE
			else if (isNext == 3) {
				elapsed += Time.deltaTime / duration;
				Camera.main.orthographicSize = Mathf.SmoothStep(orthoInFinal, startOrtho, elapsed);
				Camera.main.fieldOfView = Mathf.SmoothStep(zoomInFOV, startFOV, elapsed);
				if (elapsed > 1.0f) {
					hitDetect = false;
					isNext = 0;
				}
			}
			else if (isNext == 4) {
				elapsed += Time.deltaTime / duration;
				Camera.main.orthographicSize = Mathf.SmoothStep(orthoOutFinal, startOrtho, elapsed);
				Camera.main.fieldOfView = Mathf.SmoothStep(zoomOutFOV, startFOV, elapsed);
				if (elapsed > 1.0f) {
					hitDetect = false;
					isNext = 0;
				}
			}
		}
		else { // Check if the hit detected
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);
			//RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetMouseButtonDown(0).position), Vector2.zero);
			if(hit.collider != null && hit.collider.name != null){
				hitDetect = true;
				elapsed = 0.0f;
				Debug.Log(pageNumber);
				if (hit.collider.name == "nextPagef") {
					if (pageNumber < 27) {
						pageNumber++;
						isNext = 1;
					}
				}
				else if (hit.collider.name == "prevPagef") {
					if (pageNumber > 0) {
						pageNumber--;
						isNext = 2;
					}
				}
			}
		}
	}
}

