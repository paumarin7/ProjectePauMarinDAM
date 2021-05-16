using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamanAttack : IState
{
    EnemyChamanStates chamanStates;

    public ChamanAttack(EnemyChamanStates chamanStates)
    {
        this.chamanStates = chamanStates;
    }
    public void OnEnter()
    {
        chamanStates.chamanAnimations.Attacking = true;
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
