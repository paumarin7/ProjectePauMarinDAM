using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChamanAnimations : MonoBehaviour
{
    EnemyChamanStates chamanStates;

    private bool attacking;
    private bool alive;
    private bool createEnemy;
    private Animator animator;

    public bool CreateEnemy { get => createEnemy; set => createEnemy = value; }
    public bool Attacking { get => attacking; set => attacking = value; }
    public bool Alive { get => alive; set => alive = value; }

    // Start is called before the first frame update
    void Start()
    {
        chamanStates = GetComponent<EnemyChamanStates>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        alive = chamanStates.stats.IsAlive;
        animator.SetBool("attacking", attacking);
        animator.SetBool("alive", alive);
        animator.SetBool("createEnemy", createEnemy);
    }

    public void FinishAttack()
    {

        chamanStates.CanShoot = true;
        attacking = false;
    } 
    public void FinishCreateEnemy()
    {

        chamanStates.CanShoot = true;
        createEnemy = false;
    }
}
