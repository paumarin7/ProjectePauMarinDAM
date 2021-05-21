using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour, IAbility
{
    PlayerManager playerManager;
    public bool isEnforced = true;

    public bool usingAbility { get => isEnforced; set => isEnforced = usingAbility; }

    public void Ability()
    {
        if (isEnforced)
        {
            StartCoroutine(Enforced());
            isEnforced = false;
        }

    }

    private IEnumerator Enforced()
    {

        playerManager.playerStats.Strength += 4;
        playerManager.playerAnimations.Enforced = true;
        yield return new WaitForSeconds(4);
        playerManager.playerStats.Strength -= 4;
        playerManager.playerAnimations.Enforced = false;
        StartCoroutine(wait());
    }



    private IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        isEnforced = true;
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
