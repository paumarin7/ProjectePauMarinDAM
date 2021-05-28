using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Bullet
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


        if (other.tag == hitted || other.tag == "Bullet" || other.tag == "Floor" || other.tag == "Untagged"  || other.tag == "Minimap" || other.CompareTag("Teleport"))
        {

        }
        else
        {

            if (other.transform.gameObject.GetComponent<IDamageable>() == null)
            {
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip =(Resources.Load<AudioClip>("Sounds/StoneHit"));
                Instantiate(n, this.transform.position, Quaternion.identity);
           
            }
            else
            {
                other.transform.gameObject.GetComponent<IDamageable>().TakeHealth(damage);
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/BodyHit");
                Instantiate(n, this.transform.position, Quaternion.identity);
            }

           


            Destroy(this.gameObject);

        }

    }




}
