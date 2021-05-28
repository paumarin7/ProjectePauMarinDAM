using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour , IAbility
{
    PlayerManager playerManager;
    public bool isCreated = true;

    public bool usingAbility { get => isCreated; set => isCreated = usingAbility; }

    private AbilityCooldown ab;

    GameObject owl;

    public float time = 3;

    public void Ability()
    {
        if (isCreated)
        {
            StartCoroutine(Enforced());
            ab.SetFillAmount(1);
            ab.SetAmountTime(time + time);
            isCreated = false;
        }

    }

    private IEnumerator Enforced()
    {

        Instantiate(owl, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(wait());
    }



    private IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        isCreated = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        ab = GameObject.FindGameObjectWithTag("AbilityButton").GetComponent<AbilityCooldown>();
        playerManager = GetComponent<PlayerManager>();
        owl = Resources.Load<GameObject>("Owl");
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
