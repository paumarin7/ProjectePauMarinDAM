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

    public GameObject Player { get => player; set => player = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        mutantAnimation = GetComponent<EnemyMutantAnimation>();
        mutantMovement = GetComponent<EnemyMutantMovement>();
        Player = GameObject.FindGameObjectWithTag("Player");
        void At(IState to, IState from, System.Func<bool> condition) => mutantStateMachine.AddTransition(to, from, condition);

    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        mutantStateMachine.Tick();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
