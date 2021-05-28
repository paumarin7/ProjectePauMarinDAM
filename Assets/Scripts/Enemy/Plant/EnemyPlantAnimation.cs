using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantAnimation : MonoBehaviour
{

    EnemyPlantStates plantStates;
    private bool attacking;
    private bool alive;
    private Animator animator;

    public bool Attacking { get => attacking; set => attacking = value; }
    public bool Alive { get => alive; set => alive = value; }
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        attacking = false;
        plantStates = GetComponent<EnemyPlantStates>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("alive", alive);
        animator.SetBool("attacking", attacking);
    }


    public void FinishAttack()
    {
        plantStates.isAttacking = false;
        attacking = false;
    }
}
