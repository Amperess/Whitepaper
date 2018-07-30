using System;

public class StateManager {

    private State curState;

    public StateManager() {
        curState = null;
    }

    public void LoadState(State newState) {
        if (curState != null)
            newState.Destroy();

        curState = newState;
        curState.Init();
    }

}