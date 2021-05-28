using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBullet : Bullet
{

    public Vector3 mov;
    public bool movingAlong = true;

    public override void Start()
    {
        base.Start();
        if (gameObject.CompareTag("Bullet"))
        {
            rb = GetComponent<Rigidbody>();
            GetComponent<SphereCollider>().material = Resources.Load<PhysicMaterial>("Bounce");
            GetComponent<SphereCollider>().isTrigger = false;
           
        }


    }

    public override void Update()
    {
        SetShootDirection(enemyTransform);
        if (this.gameObject.CompareTag("Bullet"))
        {
            if (movingAlong)
            {
                rb.velocity = shootDirection * Time.deltaTime * attackSpeed * 200;
                movingAlong = false;
                //      rb.AddForce(enemyTransform * Time.deltaTime * attackSpeed, ForceMode.Impulse);
                //   rb.velocity = shootDirection * Time.deltaTime * attackSpeed * 10;
                //   transform.position += shootDirection * Time.deltaTime * attackSpeed * 10;
            }
            else
            {
              
            }


        }
    }


    private void OnTriggerEnter(Collider other)
    {
   
        IDamageable trigger = other.GetComponent<IDamageable>();


        if (other.tag == hitted || other.tag == "Bullet" || other.tag == "Untagged" || other.tag == "SecondCycle" || other.tag == "ThirdCycle" || other.tag == "Minimap")
        {

        }
        else
        {
          
           
                if (other.transform.gameObject.GetComponent<IDamageable>() == null)
                {
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = (Resources.Load<AudioClip>("Sounds/StoneHit"));
                Instantiate(n, this.transform.position, Quaternion.identity);
            }
                else
                {
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/BodyHit");
                Instantiate(n, this.transform.position, Quaternion.identity);
            }

          //      Destroy(this.gameObject);
            



        }

    }

    public void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == hitted || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "SecondCycle" || collision.gameObject.tag == "ThirdCycle" || collision.gameObject.tag == "Minimap")
        {

        }
        else
        {


            if (collision.transform.gameObject.GetComponent<IDamageable>() != null)
            {
                collision.transform.gameObject.GetComponent<IDamageable>().TakeHealth(damage);
            }

            //      Destroy(this.gameObject);




        }


       
    }
}
