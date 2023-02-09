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

        //use the inputs for moving the game object world position, using the translate vector 3
        transform.position += moveDir * playerMoveSpeed * Time.deltaTime;

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
