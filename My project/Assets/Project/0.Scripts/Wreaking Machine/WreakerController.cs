using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WB.Controller {

    public class WreakerController : MonoBehaviour
    {
        [SerializeField]
        GameObject pin;
        [SerializeField]
        GameObject rover;
        [SerializeField]
        GameObject ball;
        [SerializeField]
        GameObject body;
        [SerializeField]
        float pinSpeed = 5;
        [SerializeField]
        float roverSpeed = 5;

        Rigidbody2D rbPin;
        Rigidbody2D rbRover;
        float intervalPos = 0f;
        DistanceJoint2D ballJoint;

        void Start()
        {
            rbPin = pin.GetComponent<Rigidbody2D>();
            ballJoint = ball.GetComponent<DistanceJoint2D>();
            rbRover = body.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // Listen inputs
            float x_InputValue = Input.GetAxis("Horizontal");
            float y_InputValue = Input.GetAxis("Vertical");
            bool x_RoverNeg = Input.GetKey(KeyCode.Q);
            bool x_RoverPos = Input.GetKey(KeyCode.E);

            // Behaviours
            HorizontalPinMovement(x_InputValue);
            VerticalRopeDistance(y_InputValue);
            RoverMovement(x_RoverNeg, x_RoverPos);
            
            
            bool grounded = isGrounded(this);       // storing return type
           Body body = new Body(8, "ida-platform"); // object class
                                                    // method inside method
            Console.WriteLine(grounded);             //OOps 4 pillar abstraction, inhertance, encapsulation and polmorphism
                                                     //poc

        }

        private bool isGrounded(WreakerController wreakerController)
        {

            return false;
        }

        private void RoverMovement(bool x_RoverNeg, bool x_RoverPos)
        {
            if (x_RoverNeg && x_RoverPos || !x_RoverNeg && !x_RoverPos)
            {
                return;
            }
            else if (x_RoverPos && !x_RoverNeg)
            {
                rbRover.position = rbRover.position + new Vector2(roverSpeed * Time.deltaTime, 0f);
                //  transform.position = rbRover.position;

            }
            else if (!x_RoverPos && x_RoverNeg)
            {
                rbRover.position = rbRover.position - new Vector2(roverSpeed * Time.deltaTime, 0f);
                //  transform.position = rbRover.position;

            }
        }

        private void VerticalRopeDistance(float y_InputValue)
        {

            // Calculate the desired change in distance based on input and speed
            float desiredDistanceChange = -y_InputValue * Time.deltaTime * pinSpeed;

            // Calculate the clamped distance change within the valid range
            float clampedDistanceChange = Mathf.Clamp(desiredDistanceChange, -ballJoint.distance, 9f - ballJoint.distance);

            // Update the ballJoint.distance by adding the clamped distance change
            ballJoint.distance += clampedDistanceChange;

            // Clamp the final value between 0 and desired distance
            ballJoint.distance = Mathf.Clamp(ballJoint.distance, 0, 9f);

        }

        private void HorizontalPinMovement(float x_InputValue)
        {
            rbPin.position = new Vector2(rover.transform.position.x + intervalPos, rover.transform.position.y);

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
    //C#
    class Body {
        int id;
        string platform_ID;
       public Body(int id, string platform_ID) 
        { 
            this.id = id;
            this.platform_ID = platform_ID;
        }
    }

}
