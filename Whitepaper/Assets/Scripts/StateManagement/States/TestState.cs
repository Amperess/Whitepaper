using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.StateManagement.States
{
    class TestState : State {

        public override void Init() {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "Test Cube";
            cube.GetComponent<Renderer>().material.color = Color.cyan;
        }

        public override void Update() {
            
        }

        public override void Destroy() {

        }
    }
}
