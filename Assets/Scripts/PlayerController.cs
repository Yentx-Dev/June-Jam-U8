using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour

{

    private Rigidbody rb;
    public float horizontalMove;
    public float verticalMove;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float minSpeed = 2;
    [SerializeField] private float boostDuration = 1;
    [SerializeField] private Transform camera;

    public Vector3 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        horizontalMove = movementVector.x;
        verticalMove = movementVector.y;
    }



    void Update()
    {

        // Camera rotation
        Vector3 camForward = camera.forward;
        Vector3 camRight = camera.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        moveDirection = (camForward * verticalMove + camRight * horizontalMove);

    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * speed, ForceMode.Acceleration);
    }

    public void PlayerDie()
    {
        // Reset input & direction
        horizontalMove = 0f;
        verticalMove = 0f;
        moveDirection = Vector3.zero;

        // Kill momentum
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public IEnumerator speedBoost(float value)
    {
        // add boost
        Debug.Log($"Added speed at {Time.time}");
        addSpeed(value);
        // wait for boost duration
        yield return StartCoroutine(boostDelay());
        resetSpeed();
        Debug.Log($"Reset speed at {Time.time}");
    }

    public IEnumerator boostDelay()
    {
        yield return new WaitForSeconds(boostDuration);
    }
    public void addSpeed(float value)
    {
        speed = Math.Min(value, maxSpeed); //set to max if value>max
        Debug.Log($"Speed set to {speed}");
    }

    public void resetSpeed()
    {
        speed = minSpeed;
    }

    public float getSpeed(){return speed;}
}