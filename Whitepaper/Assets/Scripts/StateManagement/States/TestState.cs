using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.StateManagement.States
{
    class TestState : State {

        private Camera mainCamera;

        public TestState(){}

        public override void Init(){
            GameObject gameObject = MonoBehaviour.Instantiate(Resources.Load("intro1")) as GameObject;
        }

        public override void Destroy() {

        }
    }
}
