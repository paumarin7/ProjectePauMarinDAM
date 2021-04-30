using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
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
    private float accuracy;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float distance;

    public float Health { get => health; set => health = value; }
    public float Strength { get => strength; set => strength = value; }
    public float Speed { get => speed; set => speed = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float Accuracy { get => accuracy; set => accuracy = value; }
    public float Gravity { get => gravity; set => gravity = value; }
    public float Distance { get => distance; set => distance = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeHealth(float damage)
    {
        Health -= damage;

    }
}
