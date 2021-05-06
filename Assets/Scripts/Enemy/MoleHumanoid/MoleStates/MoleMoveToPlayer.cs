using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMoveToPlayer : IState
{
    private EnemyMoleStates enemyMoleStates;


    public MoleMoveToPlayer(EnemyMoleStates enemyMoleStates)
    {
        this.enemyMoleStates = enemyMoleStates;
    }

    public void OnEnter()
    {
        enemyMoleStates.moleMovement.playerDirection = new Vector3(enemyMoleStates.Player.transform.position.x - enemyMoleStates.transform.position.x, enemyMoleStates.transform.position.y, enemyMoleStates.Player.transform.position.z - enemyMoleStates.transform.position.z);
        enemyMoleStates.moleMovement.controller.detectCollisions = false;
    
    }

    public void OnExit()
    {
        enemyMoleStates.moleMovement.controller.detectCollisions = true;
    }

    public void Tick()
    {

      enemyMoleStates.moleMovement.followPlayer = new Vector3(enemyMoleStates.Player.transform.position.x - enemyMoleStates.transform.position.x, 0, enemyMoleStates.Player.transform.position.z - enemyMoleStates.transform.position.z);
      enemyMoleStates.moleMovement.controller.Move(enemyMoleStates.moleMovement.followPlayer * Time.deltaTime * enemyMoleStates.Stats.Speed);
    }
}
