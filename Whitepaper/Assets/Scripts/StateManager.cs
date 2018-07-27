public class StateManager{

    // Global state that we swap each state into
    private IState curState;

    // Default Constructor
    public StateManager(){
        this.curState = null;
    }

    // Constructor that loads current state when creating StateManager
    public StateManager(IState newState){
        this.curState = loadState(newState);
    }

    // Loads in a new
    // This function is what gets called when we want to load in a state
    public void LoadState(IState newState){

        // if the current state is not null when trying to load another state,
        // dispose before loading in new state
        if(this.curState != null){
            this.DisposeState();
        }

        // update the current state to be the new state
        this.curState = newState;

        // Initialize the current state once loaded
        this.InitState();
    }

    // Initializes current state
    // - This function is private so that we don't have to worry about a
    //   situation where we try to load and unload an current state
    private void InitState(){
        this.curState.Init();
    }

    // - Disposes current state
    // - This function is private so that we don't have to worry about a
    //   situation where we try to load and unload an current state
    private void DiposeState(){
        this.curState.Dispose();
    }


    // Renders current state
    public void RenderState(){
        this.curState.Render();
    }

    // Updates current state
    public void UpdateState(){
        this.curState.Render();
    }

}
