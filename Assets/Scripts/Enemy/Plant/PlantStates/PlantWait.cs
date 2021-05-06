using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWait : IState
{
    EnemyPlantStates plantStates;

    public PlantWait(EnemyPlantStates plantStates)
    {
        this.plantStates = plantStates;
    }

    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
    }

    public void Tick()
    {
        if (plantStates.plantMovement.playerDirection.magnitude < plantStates.plantMovement.maxRange)
        {
            plantStates.isAttacking = true;
        }
    }
}
