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


    private GameObject blood;
    private float lastHealth;

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
            Instantiate(Resources.Load<GameObject>("Particles/Blood"), new Vector3(GameManager.player.transform.position.x, GameManager.player.transform.position.y + 3, GameManager.player.transform.position.z), Quaternion.identity);
            GameObject n = Resources.Load<GameObject>("Sounds/Audio");
            n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/PlayerHurt");
            Instantiate(n, GameManager.player.transform.position, Quaternion.identity);
          
           
            GameObject.Find("Hearts").GetComponent<QuartHeart>().heartHealthSystem.Damage((int)damage);
        }
        else
        {
            Instantiate(blood, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
            health -= damage;

           
            if (gameObject.name.Equals("Mutant"))
            {
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/MutantHurt");
                Instantiate(n, GameManager.player.transform.position, Quaternion.identity);
               
            }
            else if (gameObject.name.Equals("MoleHumanoid"))
            {
                Debug.Log(gameObject.name);
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/EnemyPlant");
                Instantiate(n, GameManager.player.transform.position, Quaternion.identity);
            
            }
            else if (gameObject.name.Equals("Indigen"))
            {
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/IndigenHurt");
                Instantiate(n, GameManager.player.transform.position, Quaternion.identity);
           
            }
            else if (gameObject.name.Equals("EnemyPlant"))
            {
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/MoleHurt");
                Instantiate(n, GameManager.player.transform.position, Quaternion.identity);
            
            }
            else if (gameObject.name.Equals("Chaman"))
            {
                GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/PlayerHurt");
                Instantiate(n, GameManager.player.transform.position, Quaternion.identity);
                
            }
        
        
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
        blood = Resources.Load<GameObject>("Particles/Blood");
        lastHealth = health;
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

        if(health != lastHealth)
        {


           
            lastHealth = health;
        }
    }


    public void boostStat(string stat, float value)
    {
        switch (stat)
        {
            case "Strength":  strength += value;
                    break;
            case "Speed": speed += value; break;
            case "AttackSpeed": attackSpeed += value; break;
            case "FireRate": fireRate += value; break;
            case "Range": range += value; break;
            case "Health": maxHealth += value; break;
            

        }
    }
}
