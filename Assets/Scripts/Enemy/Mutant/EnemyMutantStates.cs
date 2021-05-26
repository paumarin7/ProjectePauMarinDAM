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
        if (stats.IsActive && stats.IsAlive)
        {
            mutantAnimation.Attacking = attacking;
            mutantAnimation.Jumping = jumping;
            if (GameManager.player != null)
            {
                Player = GameManager.player;
            }
            mutantStateMachine.Tick();
        }

    


        
    }


    public void JumpAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 7);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.transform.gameObject.name);
            if (hitCollider.transform.gameObject.GetComponent<IDamageable>() == null)
            {

            }
            else
            {
                if (hitCollider.transform.gameObject.CompareTag("Enemy"))
                {

                }
                else
                {
                   
                    hitCollider.transform.gameObject.GetComponent<IDamageable>().TakeHealth(5);
                }
       

            }
            



        }
        Instantiate(Resources.Load<GameObject>("Particles/ArtilleryExplosion"), this.transform.position, Quaternion.identity);
    }

    public void Destroy()
    {
        ActiveEnemy activ = GetComponentInParent<ActiveEnemy>();
        activ.enemy.Remove(this.stats);
        Destroy(this.gameObject);
    }
}
