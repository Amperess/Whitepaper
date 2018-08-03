using System;
using System.Collections;
using Application;
using UnityEngine;
using Assets.Scripts.StateManagement.States;

public class StateManager {

    // TODO DELETE ME
    private static TestState testState = new TestState();
    private static Intro1 intro1 = new Intro1();
    private static Intro2 intro2 = new Intro2();
    private static Intro3 intro3 = new Intro3();
    private static WpP1 wpP1 = new WpP1();
    private static WpP2 wpP2 = new WpP2();
    private static WpP4 wpP4 = new WpP4();
    private static WpP5 wpP5 = new WpP5();
    private static WpP6 wpP6 = new WpP6();
    private static WpP7 wpP7 = new WpP7();
    private static WpP8 wpP8 = new WpP8();
    private static WpP9 wpP9 = new WpP9();
    private static WpP10 wpP10 = new WpP10();


    // keeps track of if the State Manager has started
    // Used in StateManager.Start() and ensures that the state manager can only start one time
    private bool hasStarted;

    /* - State Manager is a singleton, thus we must ensure that there is only one 
     *   refernece to StateManager at all times
     * - This variable stores the one reference
     */
    private static StateManager stateManager;

    // Keeps track of the current state being rendered to the screen
    private static State currentState;
    private static string currentStateId;

    // A look up table that is used to route states to their next proper page
    private static Hashtable stateTable;


    private StateManager() {
        stateManager = null;
        currentStateId = null;
        hasStarted = false;
        stateTable = new Hashtable();
    }

    /*
     *  The constructor is private (because StatemManager.cs is a Singleton)
     *  Thus we use this create function to create an instance
     */
    public static StateManager Create() {
        if (stateManager == null) {
            stateManager = new StateManager();

            StateManager.PopulateStateGraph();
        }

        return stateManager;
    }

    /* 
     * Eventually write tool that will handle this for us at Runtime
     */
    private static void PopulateStateGraph() {
        stateTable["Intro1"] = new StateMapping(null, intro1, intro2);
        stateTable["Intro2"] = new StateMapping(intro1, intro2, intro3);
        stateTable["Intro3"] = new StateMapping(intro2, intro3, wpP1);
        stateTable["WpP1"] = new StateMapping(intro3, wpP1, wpP2);
    }

    /*
     * - StateMangaer.Start() loads in the very first state into the application
     * - Takes in a stateId - this ID is assigned to each state when said state is instantiated. 
     */
    public static void Start(string stateId) {
        try {
            // Look up stateId in stateTable and assign it to be the starting state
            StateMapping stateMap = (StateMapping)(stateTable[stateId]);

            // Set the starting state to the current state from statemap
            currentState = stateMap.Cur;
            currentStateId = stateId;

            // Once found, initialize the scene to load in the first set of assets
            currentState.Init();
        }
        catch (Exception e) {
            Debug.Log(e.StackTrace);
        }
    }



    // ******************************************************************************************
    // Don't use this code
    /*
     * - This way of storing and loading information is naive and can bog down in page loading with larger assets
     * - But for demoing purposes it's okay
     * 
     * - Purpose: Load next page
     
    public static void LoadNextState(){
        // get state id of next state
        StateMapping stateMap = (StateMapping)(stateTable[currentStateId]);
        string nextStateId = stateMap.Next;

        // destroy current state
        currentState.Destroy();

        // Set currentState to the instance of the next state and initialize all game objects
        currentState = ReflectState(nextStateId);
        currentState.Init();
    }

    /*
     * - This way of storing and loading information is naive and can bog down in page loading with larger assets
     * - But for demoing purposes it's okay
     * 
     * - Purpose: Loads previous page
     
    public static void LoadPreviousState(){
        // get state id of prev state
        StateMapping stateMap = (StateMapping)(stateTable[currentStateId]);
        string prevStateId = stateMap.Prev;

        // destroy current state
        currentState.Destroy();

        // Set currentState to the instance of the next state and initialize all game objects
        currentState = ReflectState(prevStateId);
        currentState.Init();
    }

    private static State ReflectState(string stateId){

        Debug.Log("StateId: " +  stateId);
        Type type = Type.GetType(stateId);

        Debug.Log("type: " + type);
        State reflectedState = (State)Activator.CreateInstance(type);

        return reflectedState;
    }*/

}