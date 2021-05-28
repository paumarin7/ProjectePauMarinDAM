using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackBullet : Bullet
{
    float mass = 3.0F; // defines the character mass
    Vector3 impact = Vector3.zero;

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


        if (other.tag == hitted || other.tag == "Bullet" || other.tag == "Floor" || other.tag == "Untagged" || other.tag == "SecondCycle" || other.tag == "ThirdCycle" || other.tag == "Minimap")
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
                var direction =  other.transform.position-this.transform.position;
                other.transform.gameObject.GetComponent<CharacterController>().Move( new Vector3(direction.x, 0, direction.z));

                // consumes the impact energy each cycle:

                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/BodyHit");
                Instantiate(n, this.transform.position, Quaternion.identity);
                other.transform.gameObject.GetComponent<IDamageable>().TakeHealth(damage);
            }

            Destroy(this.gameObject);

        }

    }

}
