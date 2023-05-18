using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TankShooter : MonoBehaviour
{
    [Header("Shooter")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private float repeatTime;
    public UnityEvent OnFired;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Fire()
    {
        //bulletRoutine = StartCoroutine(BulletMakeRoutine());
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        GameManager.Data.AddShootCount(1);
        animator.SetTrigger("Fire");
        OnFired?.Invoke();
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
            GameManager.Data.AddShootCount(1);
            OnFired?.Invoke();
            yield return new WaitForSeconds(repeatTime);
        }
    }
}
