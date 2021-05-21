using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    private Animator animator;
    PlayerManager playerManager;
    private bool shooting;
    private Vector3 attackRotation;
    private Vector3 rotation;


    bool walking = false;
    bool rolling = false;
    bool inmune = false;
    bool enforced = false;

    public bool Shooting { get => shooting; set => shooting = value; }
    public Vector3 AttackRotation { get => attackRotation; set => attackRotation = value; }

    public bool Walking { get => walking; set => walking = value; }
    public bool Rolling { get => rolling; set => rolling = value; }
    public bool Inmune { get => inmune; set => inmune = value; }
    public bool Enforced { get => enforced; set => enforced = value; }

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
    }


    public void setQuaternionRotation(Vector3 rotation)
    {
        this.rotation = rotation;
    }
    public Vector3 getRotation()
    {
        return rotation;
    }


    // Update is called once per frame
    void Update()
    {
        if (shooting)
        {
            this.transform.rotation = Quaternion.Euler(attackRotation);
        }
        else if(rolling)
        {
            this.transform.rotation = Quaternion.Euler(rotation);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(rotation);
        }

        animator.SetBool("walking", walking);
        animator.SetBool("rolling", rolling);
        animator.SetBool("inmune", inmune);
        animator.SetBool("enforced", enforced);
        
    }




}
