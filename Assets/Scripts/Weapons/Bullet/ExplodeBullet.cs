using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBullet : Bullet
{

    public Vector3 mov;
    public bool movingAlong = true;

    public override void Start()
    {
        base.Start();
        if (gameObject.CompareTag("Bullet"))
        {
            var g = gameObject.GetComponent<Rigidbody>();
             gameObject.GetComponent<SphereCollider>().isTrigger = true;
            g.useGravity = enabled;
         
            StartCoroutine(down(g));
           
        }


    }

    public IEnumerator down(Rigidbody g)
    {
       
        yield return new WaitForSeconds(0.3f);
        movingAlong = false;
        
        //   g.AddForce(new Vector3(0, -2000, 0), ForceMode.Force);
        SetShootDirection(new Vector3(enemyTransform.x, -10, enemyTransform.z));


    }
    public override void Update()
    {
        SetShootDirection(new Vector3(enemyTransform.x , range / 30 , enemyTransform.z));
        if (this.gameObject.CompareTag("Bullet"))
        {
            if (movingAlong)
            {
                transform.position += shootDirection * Time.deltaTime * attackSpeed * 10;
            }
            else
            {
                transform.position += shootDirection * Time.deltaTime * attackSpeed * 10;
            }
            
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        IDamageable trigger = other.GetComponent<IDamageable>();


        if (other.tag == hitted || other.tag == "Bullet"  || other.tag == "Untagged" || other.tag == "SecondCycle" || other.tag == "ThirdCycle" || other.tag == "Minimap")
        {

        }
        else
        {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
                foreach (var hitCollider in hitColliders)
                {
                    Debug.Log(hitCollider.transform.gameObject.name);
                    if(hitCollider.transform.gameObject.GetComponent<IDamageable>() == null)
                    {
                    Instantiate(Resources.Load<GameObject>("Particles/Explosion"), this.transform.position, Quaternion.identity);
                }
                    else
                    {
                    Instantiate(Resources.Load<GameObject>("Particles/Explosion"), this.transform.position, Quaternion.identity);
                    hitCollider.transform.gameObject.GetComponent<IDamageable>().TakeHealth(damage);

                    }
               
                    Destroy(this.gameObject);
                }

            

        }

    }



    private void OnDestroy()
    {
     
    }


}
