using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullets : SerializedMonoBehaviour, IItem
{
    public Type bullet = typeof(Bullet);


    public void Item(GameObject player)
    {


        var v = player.GetComponentsInChildren<Transform>();

        for (int i = 0; i < v.Length; i++)
        {
            if (v[i].gameObject.name.Equals("Weapon"))
            {
                v[i].gameObject.GetComponent<Bullet>().Destroy();
                v[i].gameObject.AddComponent(bullet);
            }
        }
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
