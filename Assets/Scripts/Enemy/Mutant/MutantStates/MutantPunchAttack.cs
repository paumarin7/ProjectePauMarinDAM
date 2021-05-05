using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantPunchAttack : IState
{

    private EnemyMutantStates enemyMutantStates;

    public MutantPunchAttack(EnemyMutantStates enemyMutantStates)
    {
        enemyMutantStates.attacking = true;
        this.enemyMutantStates = enemyMutantStates;
    }
    public void OnEnter()
    {
      
    }

    public void OnExit()
    {
        enemyMutantStates.attacking = false;
    }

    public void Tick()
    {
         enemyMutantStates.mutantMovement.controller.Move(Vector3.zero * Time.deltaTime * enemyMutantStates.stats.Speed);
    }
}
