using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    //player speed & ref to game input script
    [SerializeField] private float playerMoveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    //set player is walking for PlayerAnimation ref
    private bool playerIsWalking;
    
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();  

        //translate the vector 2 input into vector 3
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        //creat a capsule cast to check for collisions. Set paremeters for capsule cast
        float moveDistance = playerMoveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        //set up movement for only x or z if colliding with diagonal input
        //player will hug the wall instead of stopping still, makes collisions much smoother
        if (!canMove )
        {
            //cannot move towards moveDir

            //Attempt only X movement (using normized so value will be 1 - If not then it will be 0.71 and slower than moving on the X axis only) 
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if(canMove) 
            {
                //Can only move on the X axis
                moveDir = moveDirX;
            } else
            {
                //Cannot move only on the X axis
                
                //Attempt only Z movement (using normized so value will be 1 - If not then it will be 0.71 and slower than moving on the Z axis only) 
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    //Can move only on the Z axis
                    moveDir = moveDirZ;
                } else
                {
                    //Cannot move in any direction
                }
            }
        }

        //if can move is true, then allow player to move
        if (canMove)
        {
            //use the inputs for moving the game object world position, using the translate vector 3
            transform.position += moveDir * moveDistance;
        }

        //check if player is moving
        playerIsWalking = moveDir != Vector3.zero;

        //change look at position for player character, using the moveDir variable as forward ref
        float rotateSpeed = 20f;
        transform.forward = Vector3.Slerp (transform.forward, moveDir, Time.deltaTime * rotateSpeed);

        //check what input is beign assigned to input vector temp var
        //Debug.Log(inputVector);
    }

    public bool PlayerIsWalking()
    {
        //return the result of the player is walking bool, set in update
        return playerIsWalking;
    }
}
