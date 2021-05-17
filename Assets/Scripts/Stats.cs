using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float strength;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float accuracy;
    [SerializeField]
    private float range;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float distance;


    float maxHealth;

    // private bool isMoving = false;
    [SerializeField]
    // private bool isActive = false;
    private bool isAlive;
    [SerializeField]
    private bool isActive;

    public float Health { get => health; set => health = value; }
    public float Strength { get => strength; set => strength = value; }
    public float Speed { get => speed; set => speed = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float Accuracy { get => accuracy; set => accuracy = value; }
    public float Gravity { get => gravity; set => gravity = value; }
    public float Distance { get => distance; set => distance = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float Range { get => range; set => range = value; }

    public void TakeHealth(float damage)
    {

        if (this.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerDamage");
            GameObject.Find("Hearts").GetComponent<QuartHeart>().heartHealthSystem.Damage((int)damage);
        }
        else
        {
            health -= damage;
        }
       

    }

    //public bool IsMoving { get => isMoving; set => isMoving = value; }
    //public bool IsActive { get => isActive; set => isActive = value; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }
    public bool IsActive { get => isActive; set => isActive = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            IsAlive = false;
        }
        else
        {
            IsAlive = true;
        }
    }
}
