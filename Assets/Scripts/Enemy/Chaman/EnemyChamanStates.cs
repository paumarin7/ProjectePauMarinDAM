
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChamanStates : MonoBehaviour
{
    StateMachine chamanStateMachine;
    public EnemyChamanAnimations chamanAnimations;
    public EnemyChamanMovement chamanMovement;
    private GameObject player;
    public Stats stats;

    GameManager gm;


    
    public List<GameObject> chamanAlies = new List<GameObject>(); 

    public bool canShoot;

    public bool CanShoot { get => canShoot; set => canShoot = value; }

    public GameObject Player { get => player; set => player = value; }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        stats = GetComponent<Stats>();
        chamanAnimations = GetComponent<EnemyChamanAnimations>();
        chamanMovement = GetComponent<EnemyChamanMovement>();

        Player = GameManager.player;
        canShoot = true;
        chamanStateMachine = new StateMachine();


        var death = new ChamanDeath(this);
        var moveToPlayer = new ChamanMoveToPlayer(this);
        var attack = new ChamanAttack(this);
        var secondAttack = new ChamanSecondAttack(this);
        var chamanHealth = new ChamanHealth(this);
        var waitingForAttack = new ChamanWaitingForAttack(this);

        chamanStateMachine.AddAnyTransition(death, () => !stats.IsAlive);
        chamanStateMachine.AddAnyTransition(moveToPlayer, () =>   chamanMovement.playerDirection.magnitude > chamanMovement.minRange);
        chamanStateMachine.AddAnyTransition(attack, () =>  canShoot && chamanMovement.hitPlayer.collider.tag =="Player");
        chamanStateMachine.AddAnyTransition(secondAttack, () =>  (canShoot && chamanMovement.hitPlayer.collider.tag !="Player" && chamanAlies.Count < 2) || (chamanMovement.playerDirection.magnitude > chamanMovement.maxRange && chamanAlies.Count < 2));
        chamanStateMachine.AddAnyTransition(chamanHealth, () =>  (canShoot && chamanMovement.hitPlayer.collider.tag !="Player" && chamanAlies.Count == 2) || (chamanMovement.playerDirection.magnitude > chamanMovement.maxRange &&  chamanAlies.Count == 2));
        chamanStateMachine.AddAnyTransition(waitingForAttack, () => chamanMovement.playerDirection.magnitude < chamanMovement.minRange && !canShoot);


        void At(IState to, IState from, System.Func<bool> condition) => chamanStateMachine.AddTransition(to, from, condition);
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.IsActive && stats.IsAlive)
        {
            if (GameManager.player != null)
            {
                Player = GameManager.player;
            }
           
            chamanStateMachine.Tick();
        }
    }


    public IEnumerator Attack()
    {
        Debug.Log("Holji");
        //  fireRate = Time.time + fireRefreshRate;
        if (chamanMovement.hitPlayer.collider.tag == "Player")
        {
            var bullet = GetComponentInChildren<IWeapon>();
            bullet.SetDirectionShoot(transform.forward);
            bullet.SetHitted("Enemy");
            bullet.Attack();

        }


        yield return new WaitForSeconds(stats.FireRate);
        canShoot = true;
    }
    
    
    public IEnumerator CreateEnemy()
    {


   GameObject enemy =   Instantiate(gm.poolOfEnemies[Random.Range(0, gm.poolOfEnemies.Count)], chamanMovement.rayHit.transform.position, Quaternion.identity);
        
        enemy.GetComponent<Stats>().IsActive = true;

        chamanAlies.Add(enemy);

        yield return new WaitForSeconds(stats.FireRate+3);
        canShoot = true;
    }

    public void canShootTrue()
    {
        canShoot = true;
    }

    public void Attacking()
    {

        StartCoroutine(Attack());
    }


    public void Destroy()
    {

        ActiveEnemy activ = GetComponentInParent<ActiveEnemy>();
        activ.enemy.Remove(this.stats);
        Destroy(this.gameObject);
    }
}
