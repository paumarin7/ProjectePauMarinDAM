using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantStates : MonoBehaviour
{
    public Stats stats;
    private StateMachine plantStateMachine;
    public EnemyPlantAnimation plantAnimation;
    public EnemyPlantMovement plantMovement;

    private GameObject player;

    public bool isAttacking = false;

    public GameObject Player { get => player; set => player = value; }
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        Player = GameObject.FindGameObjectWithTag("Player");
        plantAnimation = GetComponent<EnemyPlantAnimation>();
        plantMovement = GetComponent<EnemyPlantMovement>();
        plantStateMachine = new StateMachine();

        var death = new PlantDeath(this);
        var wait = new PlantWait(this);
        var attack = new PlantAttack(this);

        plantStateMachine.AddAnyTransition(death, () => !stats.IsAlive);
        plantStateMachine.AddAnyTransition(wait, () => !isAttacking);
        plantStateMachine.AddAnyTransition(attack, () => isAttacking);

        void At(IState to, IState from, Func<bool> condition) => plantStateMachine.AddTransition(to, from, condition);

    }

    // Update is called once per frame
    void Update()
    {


        plantAnimation.Attacking = isAttacking;
        Player = GameObject.FindGameObjectWithTag("Player");
        plantStateMachine.Tick();
    }


    public void Attack()
    {
        var bullet = GetComponentInChildren<IWeapon>();
        bullet.SetDirectionShoot(transform.forward);
        bullet.SetHitted("Enemy");
        bullet.Attack();

    }
}
