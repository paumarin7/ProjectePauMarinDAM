using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingBullet : Bullet
{
    public override void Start()
    {
        base.Start();
        if (gameObject.CompareTag("Bullet"))
        {
            rb = GetComponent<Rigidbody>();
          
            GetComponent<SphereCollider>().isTrigger = true;

        }
    }

    public override void Update()
    {
        base.Update();
    }


    private void OnTriggerEnter(Collider other)
    {
        IDamageable trigger = other.GetComponent<IDamageable>();


        if (other.tag == hitted  || other.tag == "Floor" || other.tag == "Untagged" || other.tag == "SecondCycle" || other.tag == "ThirdCycle" || other.tag == "Minimap")
        {

        }
        else
        {
            if (other.transform.gameObject.GetComponent<IDamageable>() == null)
            {

            }
            else
            {
                other.transform.gameObject.GetComponent<IDamageable>().TakeHealth(damage);
            }

            if(other.tag == "Bullet")
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
            
            

            Destroy(this.gameObject);

        }

    }
}
