using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoleAnimation : MonoBehaviour
{
    EnemyMoleStates enemyMoleStates;
    private bool attacking;
    private bool alive;
    private Animator animator;

    public bool Attacking { get => attacking; set => attacking = value; }
    public bool Alive { get => alive; set => alive = value; }
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        enemyMoleStates = GetComponent<EnemyMoleStates>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("alive", alive);

            alive = enemyMoleStates.Stats.IsAlive;
            animator.SetBool("attacking", attacking);
         
        
      
    }

    public void FinishAttack()
    {
        enemyMoleStates.isAttacking = false;
        attacking = false;
    }
}
