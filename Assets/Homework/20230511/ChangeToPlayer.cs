using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToPlayer : MonoBehaviour
{
    private Rigidbody rigidbody;
    private void Awake()
    {
        Debug.Log("awake");
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        gameObject.name = "Player";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            Debug.Log("Jump");
        }
        
    }

}
