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
        // <게임오브젝트 접근>
        // 컴포넌트가 붙어있는 게임오브젝트는 gameObject 속성을 이용하여 접근가능
        
        // gameObject;             // 컴포넌트가 붙어있는 게임오브젝트
        // gameObject.name;        // 게임오브젝트의 이름 접근
        // gameObject.activeSelf;  // 게임오브젝트의 활성화 여부 접근
        // gameObject.tag;         // 게임오브젝트의 태그 접근
        // gameObject.layer;       // 게임오브젝트의 레이어 접근

        // <씬 내의 게임오브젝트 탐색>
        // GameObject obj = GameObject.Find("Player");                   // 이름으로 찾기
        // GameObject.FindGameObjectWithTag("Player");  // 태그로 하나 찾기
        // GameObject.FindGameObjectsWithTag("Player"); // 태그로 모두 찾기

        // <게임오브젝트 생성>
        // GameObject newObject = new GameObject();
        // newObject.name = "New Game Object";

        // <게임오브젝트 삭제>
        // if (obj != null)
        //     Destroy(obj, 5f);   // 5초 뒤 삭제
        // gameObject.name = "Player";
    }
    public void ComponentBasic()
    {
        // <게임오브젝트 내 컴포넌트 접근>
        // GetComponent를 이용하여 게임오브젝트 내 컴포넌트 접근
        audioSource = GetComponent<AudioSource>();
        // 컴포넌트에서 GetComponent를 사용할 경우 부착되어 있는 게임오브젝트를 기준으로 접근
        audioSource = gameObject.GetComponent<AudioSource>();

        gameObject.GetComponent<AudioSource>();             // 게임오브젝트의 컴포넌트 접근
        gameObject.GetComponents<AudioSource>();            // 게임오브젝트의 컴포넌트들 접근
        gameObject.GetComponentInChildren<AudioSource>();   // 자식 게임오브젝트 포함 컴포넌트 접근
        gameObject.GetComponentsInChildren<AudioSource>();  // 자식 게임오브젝트 포함 컴포넌트들 접근
        gameObject.GetComponentInParent<AudioSource>();     // 부모 게임오브젝트 포함 컴포넌트 접근
        gameObject.GetComponentsInParent<AudioSource>();    // 부모 게임오브젝트 포함 컴포넌트들 접근

        // <씬 내의 컴포넌트 탐색>
        FindObjectOfType<AudioSource>();   // 씬 내의 컴포넌트 하나 찾기
        FindObjectsOfType<AudioSource>();  // 씬 내의 컴포넌트 모두 찾기

        // <컴포넌트 추가>
        // Rigidbody rigid = new Rigidbody();	// 가능하나 의미없음, 컴포넌트는 게임오브젝트에 부착되어 동작함에 의미가 있음
        Rigidbody rigid = gameObject.AddComponent<Rigidbody>();   // 게임오브젝트에 컴포넌트 추가

        // <컴포넌트 삭제>
        Destroy(rigid);
    }
}
