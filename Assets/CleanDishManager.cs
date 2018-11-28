using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanDishManager : MonoBehaviour
{
    //for Singleton
    static CleanDishManager instance;

    //normal
    public Text score;
    public static int numOfOrganizedDish = 0;
    public static int numOfDish = 6;
    bool isTwinkled = false;
    public DishDestination dishDestination;
    public bool isMissionClear = false;

    //for Skill
    public float speedForCleanDish = 1f;
    public GameObject[] dishes;

    private void Start()
    {
        //Singleton
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        //normal
        dishes = GameObject.FindGameObjectsWithTag("Dish");
    }
    //Singleton
    public static CleanDishManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<CleanDishManager>();
            if (instance == null)
            {
                GameObject container = new GameObject("CleanDishManager");
            }
        }
        return instance;
    }

    private void Update()
    {
        if (!isTwinkled && CleanableDish.cleanDishNum >= 1)
        {
            dishDestination.StartCoroutine("Twinkling");
        }
        if (!isTwinkled && numOfOrganizedDish >= 1)
        {
            dishDestination.StopCoroutine("Twinkling");
            isTwinkled = true;
        }

        if (numOfDish <= numOfOrganizedDish)
        {
            isMissionClear = true;
        }
        else
        {
            isMissionClear = false;
        }
    }

    public float GetAccomplishment()
    {
        if(isMissionClear)
        {
            return 100f;
        }
        return 100f / numOfDish * numOfOrganizedDish;
    }

    //Skill
    public void SpeedUp1()
    {
        foreach(GameObject dish in dishes)
        {
            dish.GetComponent<CleanableDish>().maxWashNum *= 8;
            dish.GetComponent<CleanableDish>().maxWashNum /= 10;
        }
    }
    public void SpeedUp2()
    {
        foreach (GameObject dish in dishes)
        {
            dish.GetComponent<CleanableDish>().maxWashNum *= 6;
            dish.GetComponent<CleanableDish>().maxWashNum /= 10;
        }
    }
    public void SpeedUp3()
    {
        foreach (GameObject dish in dishes)
        {
            dish.GetComponent<CleanableDish>().maxWashNum *= 4;
            dish.GetComponent<CleanableDish>().maxWashNum /= 10;
        }
    }
    public void CleanDishMaster()
    {
        foreach (GameObject dish in dishes)
        {
            dish.GetComponent<CleanableDish>().maxWashNum = 2;
        }
    }
    public void CleanDishHyper()
    {
        foreach (GameObject dish in dishes)
        {
            dish.GetComponent<CleanableDish>().maxWashNum = 1;
        }
    }
}
