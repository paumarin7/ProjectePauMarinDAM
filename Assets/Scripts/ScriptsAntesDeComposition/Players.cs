using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : Character
{
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public GameObject bullet;
    public bool isMoving = false;
    private bool isActive = false;
    private bool isAlive = false;
    public List<GameObject> enemies;
    public  Vector3 moveDirection;
    public Joystick joystick;
    CharacterController controller;
    public GameObject closestEnemy;
    public GameObject playerHealthBarUi;
    public Animator animation;

    float maxHealth;
    public bool focusOnEnemy = false;


    public bool IsActive { get => isActive; set => isActive = value; }



    // Start is called before the first frame update
    protected virtual void Start()
    {
        maxHealth = Health;
        enemies = new List<GameObject>();
       
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        animation = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        playerHealthBarUi.GetComponent<Image>().fillAmount = Health / maxHealth;
        
    }

    protected virtual void FixedUpdate()
    {
        if (IsActive)
        {

            searchForFocusEnemy();
            move();
            basicAnimation();
            
          
        }
    }

    public void Attack()
    {
            if (isMoving || !focusOnEnemy)
            {
               
            }else
            {
                Instantiate(bullet, this.transform.position, this.transform.rotation);
            }
    }


    public void move()
    {
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;

        if (Health > 0 && controller.isGrounded)
        {
            moveDirection = new Vector3(horizontalMove , 0, verticalMove).normalized * Speed;
;
            controller.Move(moveDirection * Time.deltaTime);
            

        }
        else
        {
            moveDirection.y -= Gravity;
        }
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void basicAnimation()
    {
        if (isMoving && isAlive && !focusOnEnemy)
        {
            
            animation.SetFloat("x", horizontalMove);
            animation.SetFloat("z", verticalMove);
        }
        else
        {
            if (isMoving)
            {

                Vector3 positionEnemyFocused = closestEnemy.transform.position - transform.position;

                animation.SetFloat("x", positionEnemyFocused.x);
                animation.SetFloat("z", positionEnemyFocused.z);
            }
            else{
                animation.SetFloat("x", 0);
                animation.SetFloat("z", 0);
            }
            
        }
        
    }


    public void searchForFocusEnemy()
    {
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null)
                {
                    enemies.Remove(enemies[i]);
                    focusOnEnemy = false;
                }
                
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                Vector3 distance = enemies[i].transform.position - transform.position;
                if (focusOnEnemy == false || distance.sqrMagnitude < (closestEnemy.transform.position - transform.position).sqrMagnitude)
                {
                    closestEnemy = enemies[i];
                    focusOnEnemy = true;
                }
            }
        }
        else
        {
            closestEnemy = null;
            focusOnEnemy = false;
        }
    }
   

}
