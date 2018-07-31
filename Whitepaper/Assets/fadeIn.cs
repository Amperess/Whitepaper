using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeIn : MonoBehaviour {
	float alpha = 0.1f;
	SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer>();
		StartCoroutine("fade");
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator fade(){
		yield return new WaitForSeconds(Random.Range(3,7));
		for(;;){
			while(alpha <= .4f){
				alpha+=0.02f;
				sr.color = new Color(1f,1f,1f, alpha);
				yield return new WaitForSeconds(.2f);
			}
			while(alpha >= .1f){
				alpha-=0.02f;
				sr.color = new Color(1f,1f,1f, alpha);
				yield return new WaitForSeconds(.2f);
			}
			yield return new WaitForSeconds(Random.Range(5,8));
		}
	}
}
