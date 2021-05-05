using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoleMovement : MonoBehaviour
{

    EnemyMoleStates moleStates;
    public CharacterController controller;

    public Vector3 followPlayer ;
    public Vector3 playerDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        moleStates = GetComponent<EnemyMoleStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moleStates.Stats.IsAlive)
        {
            transform.LookAt(moleStates.Player.transform.position);

            playerDirection = new Vector3(moleStates.Player.transform.position.x - moleStates.transform.position.x, moleStates.transform.position.y, moleStates.Player.transform.position.z - moleStates.transform.position.z);

        }
    }
}
