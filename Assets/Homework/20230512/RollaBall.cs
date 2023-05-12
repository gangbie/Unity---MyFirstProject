using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RollaBall : MonoBehaviour
{
    private Vector3 moveDir;
    private Rigidbody rb;

    [SerializeField]
    private float movePower;
    [SerializeField]
    private float jumpPower;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.name = "Blue Ball";
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        // transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
        rb.AddForce(moveDir * movePower, ForceMode.Force);
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    private void OnJump(InputValue value)
    {
        Jump();
    }
}
