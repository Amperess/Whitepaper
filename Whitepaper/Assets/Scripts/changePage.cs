using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePage : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	public int pageNumber;
	Vector2 touchOrigin;
	public Sprite[] sprites = new Sprite[28];

	public bool clicked;
	public float zoomInFOV;
	public float orthoInFinal;
	public float zoomOutFOV;
	public float orthoOutFinal;
	public float smooth;
	public bool readyPage;


	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    	pageNumber = 0;
		loadPages();

		clicked = false;
		readyPage = false;

		zoomOutFOV = 125;
		orthoOutFinal = 20;

		zoomInFOV = 2;
		orthoInFinal = 1;

		smooth = 10;
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
		if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) {
			clicked = true;
		}

		if (clicked) {
			//RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null && hit.collider.name != null){
				if(hit.collider.name == "nextPagef"){
					if(pageNumber < 27) {
						Debug.Log(Camera.main.fieldOfView);
						Debug.Log(Camera.main.orthographicSize);
						Debug.Log(pageNumber);
						if (!(Camera.main.orthographicSize > 20 && Camera.main.fieldOfView > 125)) {
							ChangeFOV(0);
						}
						else {
							pageNumber++;
							spriteRenderer.sprite = sprites[pageNumber];
							clicked = false;
							readyPage = false;
						}
					}
				}else if(hit.collider.name == "prevPagef"){
					if(pageNumber > 0) {
						if (!((Camera.main.orthographicSize < 1 && Camera.main.fieldOfView < 2))) {
							ChangeFOV(1);
						}
						else {
							pageNumber--;
							spriteRenderer.sprite = sprites[pageNumber];
							clicked = false;
							readyPage = false;
						}
					}
				}
			}
		}
	}

	void ChangeFOV(int select) {
		float currentFOV = Camera.main.fieldOfView;
		float currentOrtho = Camera.main.orthographicSize;

		if (select == 0) {
	        if (currentFOV != zoomInFOV || currentOrtho != orthoInFinal) {
				if (currentFOV > zoomInFOV) {
					 Camera.main.fieldOfView -= (smooth * Time.deltaTime);
				}
				else {
					if (currentFOV >= zoomInFOV) {
						Camera.main.fieldOfView = zoomInFOV;
					}
	            }

	            if (currentOrtho > orthoInFinal) {
	            	Camera.main.orthographicSize -= (smooth * Time.deltaTime);
	            }
	            else {
					if (currentOrtho >= orthoInFinal) {
						Camera.main.orthographicSize = orthoInFinal;
					}
	            }
	        }
	    }

        if (select == 1) {
	        if (currentFOV != zoomOutFOV || currentOrtho != orthoOutFinal) {
				if (currentFOV < zoomOutFOV) {
					 Camera.main.fieldOfView += (smooth * Time.deltaTime);
				}
				else {
					if (currentFOV <= zoomOutFOV) {
						Camera.main.fieldOfView = zoomOutFOV;
					}

	            }

	            if (currentOrtho < orthoOutFinal) {
	            	Camera.main.orthographicSize += (smooth * Time.deltaTime);
	            }
	            else {
					if (currentOrtho <= orthoOutFinal) {
						Camera.main.orthographicSize = orthoOutFinal;
					}
	            }
	        }
	    }
	}
}
