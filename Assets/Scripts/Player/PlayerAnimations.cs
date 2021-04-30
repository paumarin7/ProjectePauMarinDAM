using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    private Animator animator;
    PlayerManager playerManager;
    bool walking = false;

    public bool Walking { get => walking; set => walking = value; }

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
            animator.SetBool("walking", walking);
        
    }




}
