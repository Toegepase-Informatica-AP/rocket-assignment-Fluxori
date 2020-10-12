using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    // control speed
    public float speed = 5;
    public float moveForceMultiplier;
    // Torque to turn the nose left and right when moving horizontally
    public float yawTorqueMagnitude = 30.0f;
    // Torque to tilt the aircraft left and right when moving horizontally
    public float rollTorqueMagnitude = 100.0f;
    // Torque to return posture like a spring
    public float restoringTorqueMagnitude = 60.0f;
    public float rotationSpeed = 0.08f;
    
    public float thrust = 13.0f;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularDrag = 20.0f;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * thrust);
        }
        float x = Input.GetAxis ("Horizontal");
        // Multiply x and y by speed
        rb.AddForce (x * speed, 0, 0);
        Vector3 moveVector = Vector3.zero;
        rb.AddForce (moveForceMultiplier * (moveVector-rb.velocity));
        // Torque to twist posture according to player input
        Vector3 rotationTorque = new Vector3 (0, 0, -x * rollTorqueMagnitude);
        // Torque to twist in the opposite direction with a magnitude proportional to the current posture deviation
        Vector3 right = transform.right;
        Vector3 up = transform.up;
        Vector3 forward = transform.forward;
        Vector3 restoringTorque = new Vector3 (forward.y-up.z, right.z-forward.x, up.x-right.y) * restoringTorqueMagnitude;
        // Add torque to the aircraft
        rb.AddTorque ((rotationTorque + restoringTorque) * rotationSpeed);
    }
}
