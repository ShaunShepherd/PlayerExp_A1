using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] float moveSpeed;
    [SerializeField] float playerHeight;
    [SerializeField] float groundedAllowance;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundDrag;
     

    [Header("References")]
    [SerializeField] Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        MovePlayer();

        if (IsGrounded())
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
    }

    bool IsGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + groundedAllowance, groundLayer);

        return isGrounded;
    }

}
