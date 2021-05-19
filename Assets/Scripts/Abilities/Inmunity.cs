using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmunity : MonoBehaviour , IAbility
{

    PlayerManager playerManager;
    public bool isInmune = true;

    public bool usingAbility { get => isInmune; set => isInmune = usingAbility; }

    public void Ability()
    {
        if (isInmune)
        {
            StartCoroutine(Inmune());
            isInmune = false;
        }

    }

    private IEnumerator Inmune()
    {

        playerManager.playerMovementManager.controller.detectCollisions = false;
        Vector3 direction = new Vector3(transform.forward.x, 0, transform.forward.z);

        playerManager.playerMovementManager.setVectorMovement(direction);

        playerManager.playerAnimations.Inmune = true;
        yield return new WaitForSeconds(4);
        playerManager.playerMovementManager.controller.detectCollisions = true;
        playerManager.playerAnimations.Inmune = false;
        isInmune = true;
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
