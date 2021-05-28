using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMutantAnimation : MonoBehaviour
{

    EnemyMutantStates mutantStates;
    private bool attacking;
    private bool alive;
    private bool jumping;

    private Animator animator;

    public bool Attacking { get => attacking; set => attacking = value; }
    public bool Alive { get => alive; set => alive = value; }
    public bool Jumping { get => jumping; set => jumping = value; }
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        mutantStates = GetComponent<EnemyMutantStates>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("alive", alive);
        if (mutantStates.stats.IsActive)
        {
            if (mutantStates.stats.IsAlive)
            {
                alive = mutantStates.stats.IsAlive;
                animator.SetBool("attacking", attacking);
               
                animator.SetBool("jumping", jumping);
            }
        }

    }

    public void FinishAttack()
    {
        mutantStates.attacking = false;
        attacking = false;
    }
    public void FinishJump()
    {
        mutantStates.jumpTimer.Reset();
        mutantStates.jumping = false;
        jumping = false;
    }
}
