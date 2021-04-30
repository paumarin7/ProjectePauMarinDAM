using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    // Clase que controla el movimiento del jugador

    private float Speed = 10;
    private Vector3 moveDirection;
    private Vector3 rotation;
    private Vector3 attackRotation;
    private CharacterController controller;

    private bool shooting;

    public bool Shooting { get => shooting; set => shooting = value; }
    public Vector3 AttackRotation { get => attackRotation; set => attackRotation = value; }


    // Start is called before the first frame update
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    public void setVectorMovement(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;
        
    }

    public void setQuaternionRotation(Vector3 rotation)
    {
        this.rotation = rotation;
    }
    
    public void setSpeedMovement(float speed)
    {
        this.Speed = speed;
    }

    public Vector3 getMoveDirection()
    {
        return moveDirection;
    }

    public Vector3 getRotation() {
        return rotation;
    }
        



    // Update is called once per frame
    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            moveDirection = (moveDirection) * Speed;

            controller.Move(moveDirection * Time.deltaTime);

           

        }
        else
        {
            moveDirection.y -= 1f;
        }
        //animations

        if (shooting)
        {
            this.transform.rotation = Quaternion.Euler(attackRotation);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(rotation);
        }
      

        controller.Move(moveDirection * Time.deltaTime);

    }
}
