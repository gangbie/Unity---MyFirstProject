using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSetting
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        // ���� �����ϱ� �� �ʿ��� ������
        if (GameManager.Instance == null)
        {
            GameObject gameManaver = new GameObject() { name = "GameManager" };
            gameManaver.AddComponent<GameManager>();
        }
    }
}
