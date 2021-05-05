using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantMoveToPlayer : IState
{

    private EnemyMutantStates enemyMutantStates;

    public MutantMoveToPlayer(EnemyMutantStates enemyMutantStates)
    {
        this.enemyMutantStates = enemyMutantStates;
    }
    public void OnEnter()
    {
        enemyMutantStates.mutantMovement.playerDirection = new Vector3(enemyMutantStates.Player.transform.position.x - enemyMutantStates.transform.position.x, enemyMutantStates.transform.position.y, enemyMutantStates.Player.transform.position.z - enemyMutantStates.transform.position.z);

    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        enemyMutantStates.mutantMovement.playerDirection = new Vector3(enemyMutantStates.Player.transform.position.x - enemyMutantStates.transform.position.x, 0, enemyMutantStates.Player.transform.position.z - enemyMutantStates.transform.position.z);
        enemyMutantStates.mutantMovement.controller.Move(enemyMutantStates.mutantMovement.playerDirection * Time.deltaTime * enemyMutantStates.stats.Speed);
    }
}
