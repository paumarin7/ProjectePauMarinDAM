using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour, IAbility
{

    PlayerManager playerManager;
    public bool isRolling = true;

    public bool usingAbility { get => isRolling; set => isRolling = usingAbility; }

    public void Ability()
    {
        if (isRolling)
        {
            StartCoroutine(Rolling());
            isRolling = false;
        }
        
    }

    private IEnumerator Rolling()
    {

        playerManager.playerMovementManager.controller.detectCollisions = false;
        Vector3 direction = new Vector3(transform.forward.x, 0, transform.forward.z);
   
        playerManager.playerMovementManager.setVectorMovement(direction);
        
        playerManager.playerAnimations.Rolling = true;
        yield return new WaitForSeconds(2);
        playerManager.playerMovementManager.controller.detectCollisions = false;
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
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
