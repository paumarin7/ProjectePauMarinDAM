using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmunity : MonoBehaviour , IAbility
{

    PlayerManager playerManager;
    public bool isInmune = true;

    private AbilityCooldown ab;
    public float time = 3;
    public bool usingAbility { get => isInmune; set => isInmune = usingAbility; }

    public void Ability()
    {
        if (isInmune)
        {
            StartCoroutine(Inmune());
            ab.SetFillAmount(1);
            ab.SetAmountTime(time + time);
            isInmune = false;
        }

    }

    private IEnumerator Inmune()
    {

        playerManager.playerMovementManager.controller.detectCollisions = false;
        Vector3 direction = new Vector3(transform.forward.x, 0, transform.forward.z);

        playerManager.playerMovementManager.setVectorMovement(direction);

        playerManager.playerAnimations.Inmune = true;
        yield return new WaitForSeconds(time);
        playerManager.playerMovementManager.controller.detectCollisions = true;
        playerManager.playerAnimations.Inmune = false;
        
        StartCoroutine(wait());
    }



    private IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        isInmune = true;
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
