using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIntoBullet : Bullet
{

   

    public override void Start()
    {
        base.Start();
        if (gameObject.CompareTag("Bullet"))
        {
            
            rb = GetComponent<Rigidbody>();
            bullet = this.gameObject;
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
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/StoneHit");
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


    private void OnDestroy()
    {
        if (create <2)
        {
            Bullet(this.transform.position, Vector3.left);
            Bullet(this.transform.position, Vector3.forward);
            Bullet(this.transform.position, -Vector3.left);
            Bullet(this.transform.position, -Vector3.forward);
        }

    }

    public void Bullet(Vector3 bulletPosition  ,Vector3 lrud)
    {
        GameObject bala = Instantiate(bullet);
      //  bala.AddComponent(GetComponent<BulletIntoBullet>().GetType());
        bala.transform.localScale = new Vector3( (transform.localScale.x / 1.25f) , (transform.localScale.y / 1.25f) , (transform.localScale.z / 1.25f));
        bala.GetComponent<Bullet>().SetDamage(damage/3);
        bala.GetComponent<Bullet>().SetAttackSpeed(attackSpeed);
        bala.GetComponent<Bullet>().Range = range/ 1.7f;
        bala.name = this.name;
        bala.GetComponent<Bullet>().SetHitted(hitted);
        bala.GetComponent<Bullet>().SetAccuracy(Accuracy);
        bala.transform.position = bulletPosition;
        bala.GetComponent<Bullet>().SetEnemyTransform(lrud);
        bala.GetComponent<Bullet>().create += 1;
        bala.GetComponent<Bullet>().enabled = true;
        bala.SetActive(true);
    }

}
