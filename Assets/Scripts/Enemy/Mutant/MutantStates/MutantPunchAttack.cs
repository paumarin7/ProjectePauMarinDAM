using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantPunchAttack : IState
{

    private EnemyMutantStates enemyMutantStates;

    public MutantPunchAttack(EnemyMutantStates enemyMutantStates)
    {
        this.enemyMutantStates = enemyMutantStates;
    }
    public void OnEnter()
    {
      
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
      
    }
}
