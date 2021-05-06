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
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }



    public void Tick()
    {
      
    }
}
