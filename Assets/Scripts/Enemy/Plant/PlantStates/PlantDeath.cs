using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDeath : IState
{
    EnemyPlantStates plantStates;

    public PlantDeath(EnemyPlantStates plantStates)
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

    }
}
