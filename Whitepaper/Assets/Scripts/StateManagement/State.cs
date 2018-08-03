using System;
using UnityEngine;

public abstract class State{
    
    public State(){}

    public abstract void Init();
    public abstract void Destroy();

}
