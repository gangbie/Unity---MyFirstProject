using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.SceneManagement;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        GameObjectBasic();
        ComponentBasic();
    }
    public void GameObjectBasic()
    {
        // <���ӿ�����Ʈ ����>
        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� gameObject �Ӽ��� �̿��Ͽ� ���ٰ���
        
        // gameObject;             // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ
        // gameObject.name;        // ���ӿ�����Ʈ�� �̸� ����
        // gameObject.activeSelf;  // ���ӿ�����Ʈ�� Ȱ��ȭ ���� ����
        // gameObject.tag;         // ���ӿ�����Ʈ�� �±� ����
        // gameObject.layer;       // ���ӿ�����Ʈ�� ���̾� ����

        // <�� ���� ���ӿ�����Ʈ Ž��>
        // GameObject obj = GameObject.Find("Player");                   // �̸����� ã��
        // GameObject.FindGameObjectWithTag("Player");  // �±׷� �ϳ� ã��
        // GameObject.FindGameObjectsWithTag("Player"); // �±׷� ��� ã��

        // <���ӿ�����Ʈ ����>
        // GameObject newObject = new GameObject();
        // newObject.name = "New Game Object";

        // <���ӿ�����Ʈ ����>
        // if (obj != null)
        //     Destroy(obj, 5f);   // 5�� �� ����
        // gameObject.name = "Player";
    }
    public void ComponentBasic()
    {
        // <���ӿ�����Ʈ �� ������Ʈ ����>
        // GetComponent�� �̿��Ͽ� ���ӿ�����Ʈ �� ������Ʈ ����
        audioSource = GetComponent<AudioSource>();
        // ������Ʈ���� GetComponent�� ����� ��� �����Ǿ� �ִ� ���ӿ�����Ʈ�� �������� ����
        audioSource = gameObject.GetComponent<AudioSource>();

        gameObject.GetComponent<AudioSource>();             // ���ӿ�����Ʈ�� ������Ʈ ����
        gameObject.GetComponents<AudioSource>();            // ���ӿ�����Ʈ�� ������Ʈ�� ����
        gameObject.GetComponentInChildren<AudioSource>();   // �ڽ� ���ӿ�����Ʈ ���� ������Ʈ ����
        gameObject.GetComponentsInChildren<AudioSource>();  // �ڽ� ���ӿ�����Ʈ ���� ������Ʈ�� ����
        gameObject.GetComponentInParent<AudioSource>();     // �θ� ���ӿ�����Ʈ ���� ������Ʈ ����
        gameObject.GetComponentsInParent<AudioSource>();    // �θ� ���ӿ�����Ʈ ���� ������Ʈ�� ����

        // <�� ���� ������Ʈ Ž��>
        FindObjectOfType<AudioSource>();   // �� ���� ������Ʈ �ϳ� ã��
        FindObjectsOfType<AudioSource>();  // �� ���� ������Ʈ ��� ã��

        // <������Ʈ �߰�>
        // Rigidbody rigid = new Rigidbody();	// �����ϳ� �ǹ̾���, ������Ʈ�� ���ӿ�����Ʈ�� �����Ǿ� �����Կ� �ǹ̰� ����
        Rigidbody rigid = gameObject.AddComponent<Rigidbody>();   // ���ӿ�����Ʈ�� ������Ʈ �߰�

        // <������Ʈ ����>
        Destroy(rigid);
    }
}
