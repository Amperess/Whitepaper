public class StateManager{

    // Stat
    private IState curState;

    // Default Constructor
    public StateManager(){
        this.curState = null;
    }

    // Constructor that loads current state when creating StateManager
    public StateManager(State newState){
        this.curState = loadState(newState);
    }

    public void LoadState(IState newState){

        // if the current state is not null, dispose before loading in new state
        if(this.curState != null){
            this.curState.dispose();
        }

        this.curState = newState;
        this.curState.init()
    }

    public void InitState(){
        this.curState.Init();
    }

    public void RenderState(){
        this.curState.Render();
    }

    public void UpdateState(){
        this.curState.Render();
    }

    public void DiposeState(){
        this.curState.Dispose();
    }
}
