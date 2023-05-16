using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniMap : MonoBehaviour
{
    [SerializeField]
    private GameObject follow;
    [SerializeField]
    private GameObject lookAt;

    [SerializeField]
    private Vector3 offset;

    private void LateUpdate()
    {
        transform.position = follow.transform.position + offset;
        transform.LookAt(lookAt.transform);
    }
}
