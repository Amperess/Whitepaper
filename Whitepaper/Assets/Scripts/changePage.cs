using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePage : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	public int pageNumber;
	Vector2 touchOrigin;
	public Sprite[] sprites = new Sprite[28];


	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    	pageNumber = 0;
		loadPages();

	}

	void loadPages () {
		for (int i=0; i<28; i++) {
			sprites[i] = Resources.Load<Sprite>(""+(i+1));
		}
	}

	// Update is called once per frame
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
}
