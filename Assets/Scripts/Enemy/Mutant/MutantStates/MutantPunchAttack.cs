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
        enemyMutantStates.attacking = true;
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
