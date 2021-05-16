using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChamanMovement : MonoBehaviour
{
    EnemyChamanStates chamanStates;

    public CharacterController controller;
    public RaycastHit hitPlayer;
    public Vector3 playerDirection;

    public GameObject rayHit;

    public float minRange;
    public float maxRange;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        chamanStates = GetComponent<EnemyChamanStates>();
        

    }


    public void SetMinRange(float minRange)
    {
        this.minRange = minRange;
    }
    public void SetMaxRange(float maxRange)
    {
        this.maxRange = maxRange;
    }

    private void FixedUpdate()
    {
        if(chamanStates.Player!= null)
        {
            Physics.Raycast(rayHit.transform.position, playerDirection, out hitPlayer, 50);

            Debug.DrawRay(transform.position, playerDirection, Color.black);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (chamanStates.stats.IsActive)
        {
            if (chamanStates.stats.IsAlive)
            {
               if(minRange  == 0  && maxRange == 0)
                {
                    SetMinRange(chamanStates.stats.Distance);
                    SetMaxRange(chamanStates.stats.Distance + 20);
                }
                transform.LookAt(chamanStates.Player.transform.position);

                playerDirection = new Vector3(chamanStates.Player.transform.position.x - transform.position.x, 0, chamanStates.Player.transform.position.z - transform.position.z);

            }
        }
    }
}
