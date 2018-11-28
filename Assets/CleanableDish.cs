using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanableDish : MonoBehaviour {
    //normal
    int nowWashNum = 0;
    public int maxWashNum = 900;
    Material orignDish;
    public Material dirtyDish;

    //for Manage
    public static int cleanDishNum = 0;
    bool isClean = false;

    //for TriggerStay
    float accTime = 0f;
    float delay = 0.1f;

    private void Start()
    {
        orignDish = GetComponent<MeshRenderer>().material;
        gameObject.GetComponent<MeshRenderer>().material = dirtyDish;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DishDestination" && isClean)
        {
            CleanDishManager.numOfOrganizedDish++;
        }

        if (nowWashNum >= maxWashNum)
            return;
        if (other.tag == "Water")
            nowWashNum++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DishDestination" && isClean)
        {
            CleanDishManager.numOfOrganizedDish--;
        }

        if (other.tag == "Water")
            if (nowWashNum >= maxWashNum && !isClean)
                ToBeClean();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Water")
        {
            accTime += Time.deltaTime;
            if (accTime > delay)
            {
                nowWashNum++;
                accTime = 0;
            }
            if (nowWashNum >= maxWashNum && !isClean)
                ToBeClean();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            ToBeDirty();
        }
    }

    public void ToBeClean()
    {
        gameObject.GetComponent<MeshRenderer>().material = orignDish;
        cleanDishNum++;
        isClean = true;
    }

    public void ToBeDirty()
    {
        gameObject.GetComponent<MeshRenderer>().material = dirtyDish;
        cleanDishNum--;
        nowWashNum = 0;
        isClean = false;
    }
}
