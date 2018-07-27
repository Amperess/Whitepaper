/**
 * - Each State that we create can represent a page in the comic, a menu,
 *   or essentially any screen that the user interacts with.
 * - Each State has a function each with their own purpose
 */
public interface IState{

    // Initialize state -- laod all game objects into the scene
    // This function is the first function that gets called and before Render or Update begin
    void Init();

    // Update State -- all the update logic for a state
    void Update();

    // Render State -- all the render logic that goes along with updating the state
    void Render();

    // Dispose State -- Any objects that must be unloaded (or set to null) is done here.
    // This function gets called before loading in the next state
    void Dispose();

}
