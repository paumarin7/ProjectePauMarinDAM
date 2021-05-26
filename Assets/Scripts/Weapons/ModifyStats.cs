using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyStats : MonoBehaviour, IItem
{
   
    public string stat;
    public float value;


    public void Item(GameObject player)
    {
       
        player.gameObject.GetComponent<Stats>().boostStat(stat, value);
        Destroy(this.gameObject);
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
