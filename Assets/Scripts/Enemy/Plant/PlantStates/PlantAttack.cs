using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : IState
{
    EnemyPlantStates plantStates;

    public PlantAttack(EnemyPlantStates plantStates)
    {
        this.plantStates = plantStates;
    }


    public void OnEnter()
    {
       
    }

    public void OnExit()
    {
       
    }
    public void Tick()
    {
        if (plantStates.plantMovement.playerDirection.magnitude > plantStates.plantMovement.maxRange)
        {
            plantStates.isAttacking = false;
        }
    }
}
