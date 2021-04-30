using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Enemies : Character
{
    public Vector3 lastPosition;
    public Vector3 firstPosition;
    public Vector3 initialPosition;
    public float maxRange;
    public float minRange;
    bool isFollowing = false;
    public bool returning = false;
    public bool idle = false;
    public bool attacking = false;
    private Animator animation;
    CharacterController controller;
    Vector3 followPlayer;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        firstPosition = transform.position;
        lastPosition = transform.position;
        initialPosition = transform.position;
        animation = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Health > 0)
        {
            basicAnimation();
            checkPlayer();
        }
        else
        {
            animation.SetLayerWeight(0, 0f);
            animation.SetLayerWeight(1, 0f);
            animation.SetLayerWeight(2, 1f);
            animation.SetBool("Attacking", false);
            animation.SetBool("Death", true);
        }
    }

    private void FixedUpdate()
    {
       // nav.destination = player.transform.position;
    }

    public void checkPlayer()
    {
        RaycastHit hitPlayer;
        

        Vector3 playerDirection = (player.transform.position - transform.position);

       
        ////Move To Player
        if (Physics.Raycast(transform.position, playerDirection, out hitPlayer, 50))
        {

            Debug.DrawRay(transform.position, playerDirection, Color.black);
            if (hitPlayer.collider.tag == "Player")
            {

                if (playerDirection.magnitude > minRange)
                {
                    attacking = false;
                    idle = false;
                    isFollowing = true;
                    followPlayer = new Vector3((player.transform.position.x - transform.position.x), 0, (player.transform.position.z - transform.position.z)).normalized * Speed;
                    controller.Move(followPlayer * Time.deltaTime);
                    //   rigidBody.MovePosition(transform.position + (playerDirection * speed * Time.deltaTime));
                    //   rigidBody.AddForce(playerDirection * speed * Time.deltaTime);
                    lastPosition = player.transform.position;
                    firstPosition = transform.position;
                }
                else
                {
                    idle = true; 
                    attacking = true;
                    //attack animation

               //     player.GetComponent<Players>().takeHealth(Strength);

                    controller.Move(Vector3.zero * Time.deltaTime);

                }
            }
            else
            {
                if (returning)
                {
                    idle = false;

                    isFollowing = false;
                    //  transform.position = Vector3.MoveTowards(transform.position, firstPosition, speed * Time.deltaTime);
                    //   rigidBody.velocity = new Vector3(firstPosition.x - transform.position.x, firstPosition.y, firstPosition.z - transform.position.z).normalized * speed;
                    if (Vector2.Distance(firstPosition, lastPosition)< 0.5)
                    {
                        followPlayer = new Vector3(initialPosition.x - transform.position.x, 0, initialPosition.z - transform.position.z).normalized * Speed;

                    }
                    else
                    {
                        followPlayer = new Vector3(firstPosition.x - transform.position.x, 0, firstPosition.z - transform.position.z).normalized * Speed;
                    }
                    controller.Move(followPlayer * Time.deltaTime);
                    if (Vector2.Distance(transform.position, firstPosition) < 0.03)
                    {
                        returning = false;
                    }
                }
                else
                {

                    idle = false;
                    isFollowing = false;
                    //   transform.position = Vector3.MoveTowards(transform.position, lastPosition, speed * Time.deltaTime);
                    // rigidBody.velocity = new Vector3(lastPosition.x - transform.position.x, lastPosition.y, lastPosition.z - transform.position.z).normalized * speed;
                    
                    if (Vector2.Distance(firstPosition, lastPosition) < 0.5)
                    {
                        followPlayer = new Vector3(initialPosition.x - transform.position.x, 0, initialPosition.z - transform.position.z).normalized * Speed;
                       
                    }
                    else
                    {
                        followPlayer = new Vector3(lastPosition.x - transform.position.x, 0, lastPosition.z - transform.position.z).normalized * Speed;
                    }
                    controller.Move(followPlayer * Time.deltaTime);
                    if (Vector2.Distance(transform.position, lastPosition) < 0.03)
                    {
                        returning = true;
                    }
                }
            }

        }
    }

    
    public void basicAnimation()
    {

        if (!idle)
        {
            animation.SetLayerWeight(0, 1f);
            animation.SetLayerWeight(1, 0f);
            attacking = false;

            if (isFollowing)
            {
                attacking = false;
                var direction = (player.transform.position - transform.position).normalized;
                animation.SetFloat("x", direction.x);
            }
            else
            {
                
                var direction = (lastPosition - transform.position).normalized;
                animation.SetFloat("x", direction.x);

            }
        }
        else
        {
            if(attacking)
            {
                animation.SetLayerWeight(0, 0f);
                animation.SetLayerWeight(1, 1f);
                animation.SetBool("Attacking", true);
            }
        }
    }


    public void takeHealth()
    {
        Debug.Log(this.name + " " + this.Strength);
        player.GetComponent<Players>().takeHealth(Strength);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

}
