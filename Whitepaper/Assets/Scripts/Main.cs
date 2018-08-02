using UnityEngine;
using Assets.Scripts.StateManagement.States;

class Main {


    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad() {

        // Creates a StateManager
        StateManager.Create();

        //Loads in the very first state
        StateManager.Start("TestState");

    }

    [RuntimeInitializeOnLoadMethod]
    static void OnSecondRuntimeMethodLoad()
    {
        // This might not be needed
    }
}