using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour, IAbility
{

    PlayerManager playerManager;
    public bool isRolling = true;

    public bool usingAbility { get => isRolling; set => isRolling = usingAbility; }


    public float time = 2;
    private AbilityCooldown ab;

    public void Ability()
    {
        if (isRolling)
        {
            StartCoroutine(Rolling());
            ab.SetFillAmount(1);
            ab.SetAmountTime(time + time);
            isRolling = false;
        }
        
    }

    private IEnumerator Rolling()
    {

        playerManager.playerMovementManager.controller.detectCollisions = false;
        Vector3 direction = new Vector3(transform.forward.x, 0, transform.forward.z);
   
        playerManager.playerMovementManager.setVectorMovement(direction);
        
        playerManager.playerAnimations.Rolling = true;
        yield return new WaitForSeconds(time);
        playerManager.playerAnimations.Rolling = false;
        playerManager.playerMovementManager.controller.detectCollisions = true;
        StartCoroutine(wait());
    }


    private IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        isRolling = true;
    }

    private void stopRoll()
    {
        playerManager.playerAnimations.Rolling = false;
        playerManager.playerMovementManager.controller.detectCollisions = true;
    }

    // Start is called before the first frame update
    void Start()
    {

        ab = GameObject.FindGameObjectWithTag("AbilityButton").GetComponent<AbilityCooldown>();
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void Destroy()
    {
        Destroy(this);
    }
}
