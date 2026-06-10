using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalMove;
    private float verticalMove;
    [SerializeField] private float speed;

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

    private void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(horizontalMove, 0, verticalMove);
        rb.AddForce(playerMovement * speed);
    }
}
