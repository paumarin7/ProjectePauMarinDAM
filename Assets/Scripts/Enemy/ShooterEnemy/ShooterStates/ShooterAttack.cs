using UnityEngine;

internal class ShooterAttack:IState
{
    private EnemyShooterStates enemyShooterStates;

    public ShooterAttack(EnemyShooterStates enemyShooterStates)
    {
        this.enemyShooterStates = enemyShooterStates;
    }

    public void OnEnter()
    {

        //    enemyShooterStates.enemyShooterAnimations.Idle = true;
        enemyShooterStates.enemyShooterMovement.playerDirection = Vector3.zero;
        enemyShooterStates.enemyShooterAnimations.Attacking = true;
    }

    public void OnExit()
    {
    //    enemyShooterStates.enemyShooterAnimations.Idle = false;
   //     enemyShooterStates.enemyShooterAnimations.Attacking = false;
      //  enemyShooterStates.CanShoot = false;
    }

    public void Tick()
    {
        enemyShooterStates.enemyShooterMovement.controller.Move(Vector3.zero);
        enemyShooterStates.CanShoot = false;
        //    enemyShooterStates.Attacking();
    }
}