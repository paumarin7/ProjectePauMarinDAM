using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAbility : SerializedMonoBehaviour, IItem
{
    public Type bullet = typeof(IAbility);


    public void Item(GameObject player)
    {



            
               player.GetComponent<IAbility>().Destroy();
               player.AddComponent(bullet);
            
        
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
