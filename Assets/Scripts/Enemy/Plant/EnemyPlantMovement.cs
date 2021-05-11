using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantMovement : MonoBehaviour
{
    EnemyPlantStates plantStates;
    public CharacterController controller;
    public Vector3 playerDirection;

    public float maxRange;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        plantStates = GetComponent<EnemyPlantStates>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plantStates.stats.IsActive)
        {
            if (plantStates.stats.IsAlive)
            {
                transform.LookAt(plantStates.Player.transform.position);

                playerDirection = new Vector3(plantStates.Player.transform.position.x - plantStates.transform.position.x, plantStates.transform.position.y, plantStates.Player.transform.position.z - plantStates.transform.position.z);
                maxRange = plantStates.stats.Distance;
            }
        }

    }
}
