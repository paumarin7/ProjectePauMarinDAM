using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantDeath : IState
{

    private EnemyMutantStates enemyMutantStates;

    public MutantDeath(EnemyMutantStates enemyMutantStates)
    {
        this.enemyMutantStates = enemyMutantStates;
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
