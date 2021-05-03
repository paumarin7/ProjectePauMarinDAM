using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterAnimations : MonoBehaviour
{
    EnemyShooterStates enemyShooterStates;
    
    private bool attacking;
    private bool alive;
    private Animator animator;



    public bool Attacking { get => attacking; set => attacking = value; }
    public bool Alive { get => alive; set => alive = value; }



    // Start is called before the first frame update
    void Start()
    {
     
        enemyShooterStates = GetComponent<EnemyShooterStates>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        alive = enemyShooterStates.Stats.IsAlive;
        animator.SetBool("attacking", attacking);
        animator.SetBool("alive", alive);
    }


    public void FinishAttack() {

        enemyShooterStates.CanShoot = true;
        attacking = false;
    }
}
