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
        Debug.Log("Attacking");
    //    enemyShooterStates.enemyShooterAnimations.Idle = true;
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

        enemyShooterStates.CanShoot = false;
        //    enemyShooterStates.Attacking();
    }
}