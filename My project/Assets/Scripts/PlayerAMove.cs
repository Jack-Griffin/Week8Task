using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAMove : MonoBehaviour
{
    // How fast the car moves (in meters per second)
    [SerializeField] private float maxSpeed;
    // The radius of the car's turning circle (in meters)
    [SerializeField] private float turningRadius;
    // How quickly the car speeds up (in meter per second squared)
    [SerializeField] private float acceleration;
    // How quickly the car slows down (in meter per second squared)
    [SerializeField] private float friction;

    // Movement speed and direction
    // Positive values mean moving forward
    // Negative values mean moving backward
    private float velocity = 0.0f;
    // Turning speed and direction
    // Positive values mean turing right
    // Negative values mean turning left
    private float angularVelocity;

    // Input fields
    private PlayerActions actions;
    private InputAction movementAction;

    private void Awake()
    {
        actions = new PlayerActions();
        movementAction = actions.PlayerA.Movement;
    }

    void OnEnable()
    {
        movementAction.Enable();
    }

    void OnDisable()
    {
        movementAction.Disable();
    }

    private void Start()
    {
        // Ensure that friction is always positive
        friction = Mathf.Abs(friction);
    }

    // Update is called once per frame
    private void Update()
    {
        // Calculate the car's velocity based on user's input
        float inputAcceleration = movementAction.ReadValue<Vector2>().y * acceleration;

        if (inputAcceleration > 0)
        {
            // Moving forward
            velocity = Mathf.Min(maxSpeed, velocity + inputAcceleration * Time.deltaTime);
        }
        else if (inputAcceleration < 0)
        {
            // Moving backward
            velocity = Mathf.Max(-maxSpeed, velocity + inputAcceleration * Time.deltaTime);
        }
        else
        {
            // Not moving, slow down the car to stop
            if (velocity > 0)
            {
                velocity = Mathf.Max(0, velocity - friction * Time.deltaTime);
            }
            else
            {
                velocity = Mathf.Min(0, velocity + friction * Time.deltaTime);
            }
        }

        // Calculate the car's angular velocity based on user's input
        angularVelocity = movementAction.ReadValue<Vector2>().x;
        // Scale angular velocity proportionally to speed to keep the 
        // radius of the car's turning circle consistent
        // We also have to convert the value from radian to degree
        angularVelocity *= velocity / turningRadius * 180 / Mathf.PI;

        // Move and turn
        transform.Translate(Vector3.forward * velocity * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up * angularVelocity * Time.deltaTime, Space.Self);
    }
}
