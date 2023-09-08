using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    [SerializeField]
    GameObject pin;
    [SerializeField]
    GameObject rover;
   
    [SerializeField]
    float pinSpeed = 5;

    Rigidbody2D rbPin;
    float intervalPos = 0f;
    float clampedValue=0f;
    void Start()
    {
        rbPin = pin.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rbPin.position = new Vector2(rover.transform.position.x + intervalPos, rover.transform.position.y - .5f);

        float x_InputValue = Input.GetAxis("Horizontal");
        float y_InputValue = Input.GetAxis("Vertical");

        HorizontalPinMovementController(x_InputValue);
        VerticalPinMovementController(y_InputValue);

    }

    private void VerticalPinMovementController(float y_InputValue)
    {

    }

    private void HorizontalPinMovementController(float x_InputValue)
    {
        if (x_InputValue > 0)
        {
            intervalPos = Mathf.Clamp(intervalPos, -1.8f, 1.8f) + x_InputValue * Time.deltaTime * pinSpeed;

            Debug.Log(intervalPos);
        }
        else if (x_InputValue < 0)
        {
            intervalPos = Mathf.Clamp(intervalPos, -1.8f, 1.8f) + x_InputValue * Time.deltaTime * pinSpeed;
            Debug.Log(intervalPos);

        }
    }
}
