using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void Movement(bool _value);
    public event Movement Event_OnPlayerMove;



    [SerializeField]
    byte moveSpeed = 7;




    private void Update()
    {

        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1; 
        }
        else if (Input.GetKey(KeyCode.S)) 
        { 
            inputVector.y = -1; 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }

        inputVector.Normalize();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        bool response = inputVector == Vector2.zero ? false : true;
        Event_OnPlayerMove?.Invoke(response);
    }




}
