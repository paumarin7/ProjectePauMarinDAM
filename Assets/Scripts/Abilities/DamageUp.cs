using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour, IAbility
{
    PlayerManager playerManager;
    public bool isEnforced = true;

    public bool usingAbility { get => isEnforced; set => isEnforced = usingAbility; }

    private AbilityCooldown ab;
    public float time = 3;
    public void Ability()
    {
        if (isEnforced)
        {
            StartCoroutine(Enforced());
            ab.SetFillAmount(1);
            ab.SetAmountTime(time + time);
            isEnforced = false;
        }

    }

    private IEnumerator Enforced()
    {

        playerManager.playerStats.Strength += 4;
        playerManager.playerAnimations.Enforced = true;
        yield return new WaitForSeconds(time);
        playerManager.playerStats.Strength -= 4;
        playerManager.playerAnimations.Enforced = false;
        StartCoroutine(wait());
    }



    private IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        isEnforced = true;
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
