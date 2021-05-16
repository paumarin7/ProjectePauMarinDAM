using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamanHealth : IState
{
    EnemyChamanStates chamanStates;

    public ChamanHealth(EnemyChamanStates chamanStates)
    {
        this.chamanStates = chamanStates;
    }
    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }
}
