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
    GameObject ball;
   
    [SerializeField]
    float pinSpeed = 5;

    Rigidbody2D rbPin;
    float intervalPos = 0f;
    float ballPos=0f;
    DistanceJoint2D ballJoint;
    void Start()
    {
        rbPin = pin.GetComponent<Rigidbody2D>();
        ballJoint = ball.GetComponent<DistanceJoint2D>();
    }

    void Update()
    {

        float x_InputValue = Input.GetAxis("Horizontal");
        float y_InputValue = Input.GetAxis("Vertical");

        HorizontalPinMovementController(x_InputValue);
        VerticalRopeDistanceController(y_InputValue);

    }

    private void VerticalRopeDistanceController(float y_InputValue)
    {

        // Calculate the desired change in distance based on input and speed
        float desiredDistanceChange = y_InputValue * Time.deltaTime * pinSpeed;

        // Calculate the clamped distance change within the valid range
        float clampedDistanceChange = Mathf.Clamp(desiredDistanceChange, -ballJoint.distance, 9f - ballJoint.distance);

        // Update the ballJoint.distance by adding the clamped distance change
        ballJoint.distance += clampedDistanceChange;

        // Clamp the final value between 0 and desired distance
        ballJoint.distance = Mathf.Clamp(ballJoint.distance, 0, 9f);

        Debug.Log(ballJoint.distance);
    }

    private void HorizontalPinMovementController(float x_InputValue)
    {
        rbPin.position = new Vector2(rover.transform.position.x + intervalPos, rover.transform.position.y );

        if (x_InputValue > 0)
        {
            intervalPos = Mathf.Clamp(intervalPos, -1.8f, 1.8f) + x_InputValue * Time.deltaTime * pinSpeed;

        }
        else if (x_InputValue < 0)
        {
            intervalPos = Mathf.Clamp(intervalPos, -1.8f, 1.8f) + x_InputValue * Time.deltaTime * pinSpeed;

        }
    }
}
