using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanDishProtoManager : MonoBehaviour {
    static CleanDishProtoManager instance;

    public Text score;

    private void Start()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    
    public static CleanDishProtoManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<CleanDishProtoManager>();
            if (instance == null)
            {
                GameObject container = new GameObject("CleanDishProtoManager");
            }
        }
        return instance;
    }

    private void Update()
    {
        score.text = CleanableDish.cleanDishNum + "/5";
    }
}
