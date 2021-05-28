using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleDamage : MonoBehaviour
{
    public string hitted;

    public float damage;


    private void Start()
    {
        damage = damage + GetComponentInParent<Stats>().Strength;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable trigger = other.GetComponent<IDamageable>();


        if (other.tag == hitted || other.tag == "Bullet" || other.tag == "Untagged" || other.tag == "SecondCycle" || other.tag == "ThirdCycle" || other.tag == "Minimap")
        {

        }
        else
        {
            //Collider[] hitColliders = Physics.OverlapSphere(transform.position, 7);
            //foreach (var hitCollider in hitColliders)
            //{
            //    Debug.Log(hitCollider.transform.gameObject.name);
            //    if (hitCollider.transform.gameObject.GetComponent<IDamageable>() == null)
            //    {

            //    }
            //    else
            //    {

            Debug.Log("Hitted" + damage);
            if (other.transform.gameObject.GetComponent<IDamageable>() != null)
            {
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/ShovelAttack1");
                Instantiate(n, GameManager.player.transform.position, Quaternion.identity);
                other.transform.gameObject.GetComponent<IDamageable>().TakeHealth(damage);
            }

            //    }
            //}
        }

    }
}
