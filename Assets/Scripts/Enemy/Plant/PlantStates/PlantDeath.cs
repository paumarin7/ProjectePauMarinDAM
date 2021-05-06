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
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }
}
