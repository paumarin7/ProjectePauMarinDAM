using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamanSecondAttack : IState
{
    EnemyChamanStates chamanStates;

    public ChamanSecondAttack(EnemyChamanStates chamanStates)
    {
        this.chamanStates = chamanStates;
    }
    public void OnEnter()
    {
        chamanStates.chamanAnimations.CreateEnemy = true;
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        chamanStates.chamanMovement.controller.Move(Vector3.zero);
        chamanStates.canShoot = false;
    }
}
