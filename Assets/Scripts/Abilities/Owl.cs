﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour , IAbility
{
    PlayerManager playerManager;
    public bool isCreated = true;

    public bool usingAbility { get => isCreated; set => isCreated = usingAbility; }

    GameObject owl;

    public void Ability()
    {
        if (isCreated)
        {
            StartCoroutine(Enforced());
            isCreated = false;
        }

    }

    private IEnumerator Enforced()
    {

        Instantiate(owl, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(1);
        StartCoroutine(wait());
    }



    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        isCreated = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        owl = Resources.Load<GameObject>("Owl");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
