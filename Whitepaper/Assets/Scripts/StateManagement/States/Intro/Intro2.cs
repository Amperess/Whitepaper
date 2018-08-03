using System;
using UnityEngine;

namespace Application {
    public class Intro2 : State{
        
        public Intro2() {
        }

        public override void Destroy() {
            
        }

        public override void Init() {
            GameObject page = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Page")) as GameObject;
            SpriteRenderer spriteRenderer = page.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("intro3");

            GameObject nextPage = MonoBehaviour.Instantiate(Resources.Load("Prefabs/nextPagef")) as GameObject;
            GameObject prevPage = MonoBehaviour.Instantiate(Resources.Load("Prefabs/prevPagef")) as GameObject;

        }
    }
}
