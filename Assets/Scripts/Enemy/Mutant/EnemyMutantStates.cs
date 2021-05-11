using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMutantStates : MonoBehaviour
{
    private StateMachine mutantStateMachine;
    public EnemyMutantAnimation mutantAnimation;
    public EnemyMutantMovement mutantMovement;
    [SerializeField]
    private GameObject player;
    public Animator animations;
    public Stats stats;

    public Delay jumpTimer;


    public GameObject hips;

    public bool attacking;
    public bool jumping;
    public bool stopMove;

    public GameObject Player { get => player; set => player = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        mutantAnimation = GetComponent<EnemyMutantAnimation>();
        mutantMovement = GetComponent<EnemyMutantMovement>();
        Player = GameManager.player;
        jumpTimer = new Delay(stats.FireRate);
        
        mutantStateMachine = new StateMachine();

        var death = new MutantDeath(this);
        var moveToPlayer = new MutantMoveToPlayer(this);
        var punchAttack = new MutantPunchAttack(this);
        var jumpAttack = new MutantJumpAttack(this);


        mutantStateMachine.AddAnyTransition(death, () => !stats.IsAlive);
        mutantStateMachine.AddAnyTransition(moveToPlayer, () => !jumping && !attacking);
        mutantStateMachine.AddAnyTransition(jumpAttack, () => !attacking && jumping && mutantMovement.playerDirection.magnitude > mutantMovement.MinRange && mutantMovement.playerDirection.magnitude < mutantMovement.MaxRange);
        mutantStateMachine.AddAnyTransition(punchAttack, () => attacking && !jumping && mutantMovement.playerDirection.magnitude < mutantMovement.MinRange);


        void At(IState to, IState from, System.Func<bool> condition) => mutantStateMachine.AddTransition(to, from, condition);

    }

    // Update is called once per frame
    void Update()
    {

        //if (mutantMovement.playerDirection.magnitude > mutantMovement.MinRange+2  && jumpTimer.IsReady)
        //{

        //    jumping = true;
        //}
        //else if(mutantMovement.playerDirection.magnitude < mutantMovement.MinRange)
        //{
        //    attacking = true;

        //}
        if (stats.IsActive)
        {
            mutantAnimation.Attacking = attacking;
            mutantAnimation.Jumping = jumping;
            Player = GameManager.player;
            mutantStateMachine.Tick();
        }

    


        
    }




    public void Destroy()
    {
        ActiveEnemy activ = GetComponentInParent<ActiveEnemy>();
        activ.enemy.Remove(this.stats);
        Destroy(this.gameObject);
    }
}
