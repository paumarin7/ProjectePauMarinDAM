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
       enemyMutantStates.jumping = true;
        enemyMutantStates.stopMove = false;
    }

    public void OnExit()
    {
        enemyMutantStates.mutantMovement.controller.Move(Vector3.zero);
        enemyMutantStates.jumping = false;

    }

    public void Tick()
    {
       
        if (!enemyMutantStates.stopMove)
        {
            enemyMutantStates.mutantMovement.controller.Move(enemyMutantStates.transform.forward * Time.deltaTime * 6);

        }
    }
}
