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

        moveDirection = new Vector3(HorizontalMove, 0, VerticalMove).normalized;
        playerManager.playerMovementManager.setVectorMovement(moveDirection);


    }


}
