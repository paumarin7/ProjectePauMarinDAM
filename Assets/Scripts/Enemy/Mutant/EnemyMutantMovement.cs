using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMutantMovement : MonoBehaviour
{
    EnemyMutantStates enemyMutantStates;
    public CharacterController controller;

    public Vector3 playerDirection;
    [SerializeField]
    private float minRange;
    [SerializeField]
    private float maxRange;

    public float MinRange { get => minRange; set => minRange = value; }
    public float MaxRange { get => maxRange; set => maxRange = value; }

    // Start is called before the first frame update
    void Start()
    {
       
        controller = GetComponent<CharacterController>();
        enemyMutantStates = GetComponent<EnemyMutantStates>();

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyMutantStates.stats.IsActive)
        {
            if (enemyMutantStates.stats.IsAlive)
            {
                minRange = enemyMutantStates.stats.Distance;
                maxRange = enemyMutantStates.stats.Distance + 7;
                if (!enemyMutantStates.jumping)
                {
                    //   transform.LookAt(enemyMutantStates.Player.transform.position);
                    Quaternion toRotation = Quaternion.LookRotation(playerDirection);
                    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 4 * Time.deltaTime);
                }


                playerDirection = new Vector3(enemyMutantStates.Player.transform.position.x - transform.position.x, enemyMutantStates.Player.transform.position.y, enemyMutantStates.Player.transform.position.z - transform.position.z);

            }
        }
 
    }


    public void StopMove()
    {


        
        enemyMutantStates.stopMove = true;
        controller.Move(Vector3.zero);
    }
}
