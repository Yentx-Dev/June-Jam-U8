using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalMove;
    private float verticalMove;
    [SerializeField] private float speed;

    [SerializeField] private Transform camera;

    private Vector3 moveDirection;

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
}
