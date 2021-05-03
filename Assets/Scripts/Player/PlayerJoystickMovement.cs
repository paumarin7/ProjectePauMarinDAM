using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickMovement : MonoBehaviour
{
    float horizontalMove = 0f;
    float verticalMove = 0f;

    public Vector3 moveDirection;
    public Joystick joystick;
    private PlayerManager playerManager;
    private Vector3 rotation;
    private Vector3 lastRotation;

    public float HorizontalMove { get => horizontalMove; set => horizontalMove = value; }
    public float VerticalMove { get => verticalMove; set => verticalMove = value; }

    // Start is called before the first frame update
    void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        joystick = GameObject.Find("FixedJoystick").GetComponent<Joystick>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        
        HorizontalMove = joystick.Horizontal;
        VerticalMove = joystick.Vertical;

        if (this.transform.rotation.y != 0)
        {
            lastRotation = this.transform.rotation.eulerAngles;
        }

        rotation = new Vector3(0, Mathf.Atan2( joystick.Horizontal, joystick.Vertical) * 180 / Mathf.PI, 0);
        moveDirection = new Vector3(HorizontalMove, 0, VerticalMove).normalized;


        if(rotation == Vector3.zero)
        {
            playerManager.playerAnimations.setQuaternionRotation(lastRotation);
        }
        else
        {
            playerManager.playerAnimations.setQuaternionRotation(rotation);
        }
        
        if(moveDirection == Vector3.zero)
        {
            playerManager.playerMovementManager.setVectorMovement(moveDirection);
            playerManager.playerAnimations.Walking = false;
        }
        else
        {
            playerManager.playerMovementManager.setVectorMovement(moveDirection);
            playerManager.playerAnimations.Walking = true;
        }
       
        


    }
}
