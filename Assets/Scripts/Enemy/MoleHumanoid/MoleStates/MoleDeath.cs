using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleDeath : IState
{

    private EnemyMoleStates enemyMoleStates;


    public MoleDeath(EnemyMoleStates enemyMoleStates)
    {
        this.enemyMoleStates = enemyMoleStates;
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
