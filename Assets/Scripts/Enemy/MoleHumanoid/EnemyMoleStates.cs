using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoleStates : MonoBehaviour
{
    public Stats Stats;
    private StateMachine moleStateMachine;
    public EnemyMoleAnimation moleAnimation;
    public EnemyMoleMovement moleMovement;
    [SerializeField]
    private GameObject player;

    public bool isAttacking = false;



    public GameObject Player { get => player; set => player = value; }

    // Start is called before the first frame update
    void Start()
    {
        Stats = GetComponent<Stats>();
        Player = GameObject.FindGameObjectWithTag("Player");
        moleAnimation = GetComponent<EnemyMoleAnimation>();
        moleMovement = GetComponent<EnemyMoleMovement>();
        moleStateMachine = new StateMachine();

        var death = new MoleDeath(this);
        var moveToPlayer = new MoleMoveToPlayer(this);
        var attack = new MoleAttack(this);



        moleStateMachine.AddAnyTransition(death, () => !Stats.IsAlive);
        moleStateMachine.AddAnyTransition(moveToPlayer, () => !isAttacking);
        moleStateMachine.AddAnyTransition(attack, () => isAttacking);


        void At(IState to, IState from, Func<bool> condition) => moleStateMachine.AddTransition(to, from, condition);
    }

    // Update is called once per frame
    void Update()
    {


        if (Stats.IsActive)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            moleStateMachine.Tick();
        }
    
    }


    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
