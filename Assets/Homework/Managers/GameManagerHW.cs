using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerHW : MonoBehaviour
{
    private static GameManagerHW instance;
    private static DataManagerHW dataManager;
    public static GameManagerHW Instance { get { return instance; } }
    public static DataManagerHW Data { get { return dataManager; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
        instance = this;
        InitManagers();
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    private void InitManagers()
    {
        // DataManager init
        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManagerHW>();
    }
}
