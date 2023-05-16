using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowTank : MonoBehaviour
{
    /*
    public GameObject player;
    public float xmove = 0;  // X�� ���� �̵���
    public float ymove = 0;  // Y�� ���� �̵���
    public float distance = 10;

    // Update is called once per frame
    void Update()
    {
        //  ���콺 ��Ŭ�� �߿��� ī�޶� ���� ����
        //if (Input.GetMouseButton(1))
        //{
            xmove += Input.GetAxis("Mouse X"); // ���콺�� �¿� �̵����� xmove �� �����մϴ�.
            ymove -= Input.GetAxis("Mouse Y"); // ���콺�� ���� �̵����� ymove �� �����մϴ�.
        //}
        transform.rotation = Quaternion.Euler(ymove, xmove, 0); // �̵����� ���� ī�޶��� �ٶ󺸴� ������ �����մϴ�.
        Vector3 reverseDistance = new Vector3(0.0f, -3.0f, distance); // ī�޶� �ٶ󺸴� �չ����� Z ���Դϴ�. �̵����� ���� Z ������� ���͸� ���մϴ�.
        transform.position = player.transform.position - transform.rotation * reverseDistance; // �÷��̾��� ��ġ���� ī�޶� �ٶ󺸴� ���⿡ ���Ͱ��� ������ ��� ��ǥ�� �����մϴ�.
    }
    */
    [SerializeField]
    private CinemachineVirtualCamera playerCam;
    [SerializeField]
    private CinemachineVirtualCamera zoomCam;

    private void OnSetPriority1(InputValue value)
    {
        Debug.Log("Camera1 Focused");
        playerCam.Priority = 20;
        zoomCam.Priority = 0;
    }

    private void OnSetPriority2(InputValue value)
    {
        Debug.Log("Camera2 Focused");
        playerCam.Priority = 0;
        zoomCam.Priority = 20;
    }

}
