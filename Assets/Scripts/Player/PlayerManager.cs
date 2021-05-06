using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public MovementManager playerMovementManager;
    public Stats playerStats;
    public IAbility ability;
    public PlayerAnimations playerAnimations;
    public PlayerAttack playerAttack;


    public void TakeHealth(float damage)
    {
        playerStats.Health -= damage;
    }

    // Start is called before the first frame update
    void Awake()
    {
        ability = GetComponent<IAbility>();
        playerStats = GetComponent<Stats>();
        playerMovementManager = GetComponent<MovementManager>();
        playerAnimations = GetComponent<PlayerAnimations>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAttack.SetFireRate(playerStats.FireRate);
        if (ability != null)
        {
            if (ability.usingAbility)
            {
                playerMovementManager.setSpeedMovement(playerStats.Speed);
            }
            else
            {
                playerMovementManager.setSpeedMovement(playerStats.Speed + 2);

            }
        }
        else
        {
            playerMovementManager.setSpeedMovement(playerStats.Speed);
        }



    }
}
