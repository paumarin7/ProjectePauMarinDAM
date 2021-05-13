using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDirectionManager : MonoBehaviour
{
    private Vector3 shootDirection;
    private float attackSpeed;
    private float range;
    private float damage;
    private string hitted;


    private Rigidbody rb;

    public float Range { get => range; set => range = value; }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetHitted(string hitted)
    {
        this.hitted = hitted;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (this.gameObject.name.Equals("Diente"))
        {
            StartCoroutine(rangeDistance());
        }
       
    }
    public void SetShootDirection(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection;
    }

    public void SetAttackSpeed(float attackSpeed)
    {
        this.attackSpeed = attackSpeed;
    }

    public IEnumerator rangeDistance()
    {
        yield return new WaitForSeconds(Range);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    //    rb.AddForce(shootDirection * attackSpeed * Time.deltaTime, ForceMode.Impulse) ;
           transform.position += shootDirection * Time.deltaTime * attackSpeed * 10;
       // rb.velocity =  shootDirection * Time.deltaTime * attackSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable trigger = other.GetComponent<IDamageable>();
        if (other.tag == hitted || other.tag == "Bullet" || other.tag == "Floor" || other.tag =="Untagged" || other.tag == "SecondCycle" || other.tag == "ThirdCycle" || other.tag == "Minimap")
        {

        }
        else
        {
            if (trigger != null)
            {
                trigger.TakeHealth(damage);
            }

            Destroy(this.gameObject);

        }

    }
}
