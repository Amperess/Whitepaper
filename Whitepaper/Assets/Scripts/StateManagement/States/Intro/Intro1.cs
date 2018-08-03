using System;
using UnityEngine;
using UnityEngine.UI;

namespace Application {
    public class Intro1 : State {
        
        public Intro1() {}

        public override void Destroy() {
            
        }

        public override void Init() {
            GameObject page = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Page")) as GameObject;
            SpriteRenderer spriteRenderer = page.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("intro1");

            GameObject nextPage = MonoBehaviour.Instantiate(Resources.Load("Prefabs/nextPagef")) as GameObject;
            nextPage.AddComponent<detectTouch>();
            nextPage.AddComponent<RectMask2D>();
            nextPage.renderer..color = Color.red;
        }
    }
}
