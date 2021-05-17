using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamanHealth : IState
{
    EnemyChamanStates chamanStates;

    public ChamanHealth(EnemyChamanStates chamanStates)
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
        if(chamanStates.stats.MaxHealth >= chamanStates.stats.Health)
        {
            chamanStates.stats.Health += 0.005f;
            Debug.Log("Aqui");
        }
        else
        {
          
            
        }
       
    }
}
