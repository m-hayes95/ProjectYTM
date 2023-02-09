using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    //ref to player input actions script (new movement)
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        //set a new player input
        playerInputActions = new PlayerInputActions();
        //enable the new Player movement on input actions script
        playerInputActions.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized()
    {
        /*Legacy inputs:
        //assign new vector for player movement. Using vector 2 as game only has x and y movement
        Vector2 inputVector = new Vector2(0, 0);
        //get inputs for new vector
        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        */

        //new input settings. Player Move on the input class created reads vector 2.
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        //normalise the new vector so moving across mutliple axis is the same speed as moving across a single axis
        inputVector = inputVector.normalized;

        //Debug.Log(inputVector);
        return inputVector;
    }

}
