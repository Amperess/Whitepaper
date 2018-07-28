using UnityEngine;
using Assets.Scripts.StateManagement.States;

class Main {

    private static StateManager stateManager;

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad() {
        Debug.Log("LOADING FIRST STATE");
        stateManager = new StateManager();
        stateManager.LoadState(new TestState());
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnSecondRuntimeMethodLoad()
    {
        // This might not be needed
    }
}