﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamanDeath : IState
{
    EnemyChamanStates chamanStates;

    public ChamanDeath(EnemyChamanStates chamanStates)
    {
        this.chamanStates = chamanStates;
    }
    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }
}
