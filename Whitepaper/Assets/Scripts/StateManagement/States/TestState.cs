﻿using System;
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
            Debug.Log("Made it here ");
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "Test Cube";
            cube.GetComponent<Renderer>().material.color = Color.black;
        }

        public override void Destroy() {

        }
    }
}
