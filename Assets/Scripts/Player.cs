using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed = 7f;
    
    private void Update()
    {
        //assign new vector for player movement.
        //using vector 2 as game only has x and y movement
        Vector2 inputVector = new Vector2(0, 0);

        //get inputs for new vector
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        if(Input.GetKey(KeyCode.A)) 
        {
            inputVector.x = -1;
        } 
        

        //normalise the new vector so moving across mutliple axis is the same speed as moving across a single axis
        inputVector = inputVector.normalized;

        //translate the vector 2 input into vector 3
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        //use the inputs for moving the game object world position, using the translate vector 3
        transform.position += moveDir * playerMoveSpeed * Time.deltaTime;

        //check what input is beign assigned to input vector temp var
        Debug.Log(inputVector);
    }
}
