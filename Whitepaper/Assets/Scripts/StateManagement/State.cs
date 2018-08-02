using System;
using UnityEngine;

public class State
{

    // prev and next represent the pages that come before and after
    protected State prev;
    protected State next;

    /*
     * - This is a boolean that we toggle when a page is loaded or destroyeds
     * - This boolean automatically toggled on the creation of a State and 
     *   when the state is destroyed
     * - This lets the state manager know if the page is already loaded when
     *   flipping pages
     */ 
    protected bool isLoaded;
    
    // Fancy Getter 
    public bool IsLoaded{
        get { return isLoaded; }
    }

    public State(State prev, State next){
        this.prev = prev;
        this.next = next;
    }

    // Function is called 
    public virtual void Init(){
        this.isLoaded = true;
    }

    public virtual void Destroy(){
        this.isLoaded = false;
    }

}


