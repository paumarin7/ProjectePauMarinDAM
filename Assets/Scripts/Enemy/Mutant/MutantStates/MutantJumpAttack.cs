using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantJumpAttack : IState
{
    private EnemyMutantStates enemyMutantStates;

    public MutantJumpAttack(EnemyMutantStates enemyMutantStates)
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
        Debug.Log("djfifgj");
        enemyMutantStates.mutantMovement.controller.Move(Vector3.forward * Time.deltaTime * enemyMutantStates.stats.Speed);
    }
}
