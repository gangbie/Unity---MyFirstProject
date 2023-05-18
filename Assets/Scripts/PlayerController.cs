using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
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

    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
        Rotate();
        //LookAt();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
        //rb.AddForce(moveDir * movePower, ForceMode.Force);
    }
    private void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.Self);
    }

    public void Rotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 rotation = transform.rotation.ToEulerAngles();
    }

    public void LookAt()
    {
        transform.LookAt(new Vector3(0, 0, 0));
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
    public void Fire()
    {
        //bulletRoutine = StartCoroutine(BulletMakeRoutine());
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        animator.SetTrigger("Fire");

        GameManager.Data.AddShootCount(1);
    }

    private Coroutine bulletRoutine;
    private void OnFire(InputValue value)
    {
        // GameObject obj = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
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
            GameManager.Data.AddShootCount(1);
            yield return new WaitForSeconds(repeatTime);
        }
    }

    // private void OnRepeatFire(InputValue value)
    // {
    //     if (value.isPressed)
    //     {
    //         bulletRoutine = StartCoroutine(BulletMakeRoutine());
    //     }
    //     else
    //     {
    //         StopCoroutine(bulletRoutine);
    //     }
    // }
}
