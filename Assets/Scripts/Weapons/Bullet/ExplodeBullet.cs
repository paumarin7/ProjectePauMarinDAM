using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBullet : Bullet
{

    public override void Start()
    {
        base.Start();


    }
    public override void Update()
    {
        base.Update();
        if (gameObject.CompareTag("Bullet"))
        {
            
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        IDamageable trigger = other.GetComponent<IDamageable>();


        if (other.tag == hitted || other.tag == "Bullet" || other.tag == "Floor" || other.tag == "Untagged" || other.tag == "SecondCycle" || other.tag == "ThirdCycle" || other.tag == "Minimap")
        {

        }
        else
        {
            if (trigger != null)
            {

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20);
                foreach (var hitCollider in hitColliders)
                {
                    Debug.Log(hitCollider.transform.gameObject.name);
                    if(hitCollider.transform.gameObject.GetComponent<IDamageable>() == null)
                    {

                    }
                    else
                    {
                        hitCollider.transform.gameObject.GetComponent<IDamageable>().TakeHealth(damage);
                    }
               
                    Destroy(this.gameObject);

                }
            //    trigger.TakeHealth(damage);
            }

            

        }

    }

    public override IEnumerator rangeDistance()
    {
        yield return new WaitForSeconds(range);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.transform.gameObject.name);
            if (hitCollider.transform.gameObject.GetComponent<IDamageable>() == null)
            {

            }
            else
            {
                hitCollider.transform.gameObject.GetComponent<IDamageable>().TakeHealth(damage);
            }
            
            Destroy(this.gameObject);
        }
    
    }
}
