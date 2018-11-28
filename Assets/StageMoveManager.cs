using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMoveManager : MonoBehaviour {
    static GameObject[] objs;
    public GameObject[] hideGameObjects;

    private void Start()
    {
        DontDestroyOnLoad(this);
        objs = hideGameObjects;

    }

    void LoadAnotherScene()
    {
        foreach(GameObject obj in objs)
        {
            obj.SetActive(false);
        }
    }

    public static void ComeBackMenu()
    {
        foreach (GameObject obj in objs)
        {
            obj.SetActive(true);
        }
    }

    public void StartStage01()
    {
        LoadAnotherScene();
        SceneManager.LoadScene("Stage_01",LoadSceneMode.Additive);
    }
}
