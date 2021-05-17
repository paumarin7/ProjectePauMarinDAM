﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRangeUp : MonoBehaviour , IItem
{
    public float value;

    public void Item(GameObject player)
    {
        player.GetComponent<Stats>().Range += value;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            Item(other.gameObject);
        }

    }
}