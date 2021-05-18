using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddShooters : SerializedMonoBehaviour, IItem
{
    
    public Type weapon = typeof(IWeapon);
   

    public void Item(GameObject player)
    {

      
        var v =  player.GetComponentsInChildren<Transform>();

        for (int i = 0; i < v.Length; i++)
        {
            if (v[i].gameObject.name.Equals("Weapon"))
            {
                v[i].gameObject.GetComponent<IWeapon>().Destroy();
                v[i].gameObject.AddComponent(weapon);
            }
        }
      
    
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
