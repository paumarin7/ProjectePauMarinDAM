using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleAttack : IState
{

    EnemyMoleStates enemyMoleStates;

    public MoleAttack(EnemyMoleStates enemyMoleStates)
    {
        this.enemyMoleStates = enemyMoleStates;
    }
public void OnEnter()
    {
      //  throw new System.NotImplementedException();
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        Debug.Log("MoleAttack");
        enemyMoleStates.moleAnimation.Attacking = enemyMoleStates.isAttacking;
    }
}
