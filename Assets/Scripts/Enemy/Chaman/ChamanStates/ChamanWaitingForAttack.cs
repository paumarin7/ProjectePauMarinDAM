using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamanWaitingForAttack : IState
{
    EnemyChamanStates chamanStates;

    public ChamanWaitingForAttack(EnemyChamanStates chamanStates)
    {
        this.chamanStates = chamanStates;
    }
    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        chamanStates.chamanMovement.controller.Move(Vector3.zero);
    }
}
