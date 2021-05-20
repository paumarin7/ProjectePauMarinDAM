using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IShootable
{
    [SerializeField]
    protected Vector3 enemyTransform;

    protected WeaponDirectionManager weaponDirectionManager;
    protected float Accuracy;
    protected GameObject bullet;
    protected Vector3 shootDirection;
    protected float attackSpeed;
    protected float range;
    protected float damage;
    protected string hitted;


    

    public float Range { get => range; set => range = value; }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetHitted(string hitted)
    {
        this.hitted = hitted;
    }

    public void SetEnemyTransform(Vector3 enemyTransform)
    {
        this.enemyTransform = enemyTransform;
    }
    public void SetAccuracy(float Accuracy)
    {
        this.Accuracy = Accuracy;
    }

    public void SetShootDirection(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection;
    }

    public void SetAttackSpeed(float attackSpeed)
    {
        this.attackSpeed = attackSpeed;
    }

    public virtual IEnumerator rangeDistance()
    {
        yield return new WaitForSeconds(range);

        Destroy(this.gameObject);
    }
    public virtual void Start()
    {
        if (enemyTransform != null)
        {
            
            if (this.gameObject.CompareTag("Bullet"))
            {
                StartCoroutine(rangeDistance());
            }
        }

        Debug.DrawRay(transform.position, enemyTransform, Color.red, 1f);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        SetShootDirection(enemyTransform);
        if (this.gameObject.CompareTag("Bullet"))
        {
            transform.position += shootDirection * Time.deltaTime * attackSpeed * 10;
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
                trigger.TakeHealth(damage);
            }

            Destroy(this.gameObject);

        }

    }
}
