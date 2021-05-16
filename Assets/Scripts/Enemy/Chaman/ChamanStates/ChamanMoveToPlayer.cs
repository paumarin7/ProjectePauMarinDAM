using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamanMoveToPlayer : IState
{
    EnemyChamanStates chamanStates;

    public ChamanMoveToPlayer(EnemyChamanStates chamanStates)
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
        chamanStates.chamanMovement.controller.Move(chamanStates.chamanMovement.playerDirection * Time.deltaTime * chamanStates.stats.Speed);

    }
}
