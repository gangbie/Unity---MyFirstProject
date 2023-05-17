using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    private Vector3 moveDir;
    private Rigidbody rb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpPower;
    [Header("Shooter")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private float repeatTime;
    [SerializeField] private CinemachineVirtualCamera zoomCam;

    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.name = "GreenTank";
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
        Rotate();
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
    }
    private void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.Self);
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
    private void OnZoom(InputValue value)
    {
        if(zoomCam.Priority == 5)
        {
            Debug.Log("focused");
            zoomCam.Priority = 100;
        }
        else
        {
            Debug.Log("unfocused");
            zoomCam.Priority = 5;
        }
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
    public void Fire()
    {
        //bulletRoutine = StartCoroutine(BulletMakeRoutine());
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        animator.SetTrigger("Fire");
    }

    private Coroutine bulletRoutine;
    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            bulletRoutine = StartCoroutine(BulletMakeRoutine());
            animator.SetTrigger("Fire");
        }
        else
        {
            StopCoroutine(bulletRoutine);
        }
    }
    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            yield return new WaitForSeconds(repeatTime);
        }
    }
}
