﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanableDish : MonoBehaviour {
    //normal
    float nowWashNum = 0;
    public int maxWashNum = 900;
    Material orignDish;
    public Material dirtyDish;

    //for Manage
    public static int cleanDishNum = 0;
    public static int WashingNum = 0;
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
	//When washing dish
        if (nowWashNum >= maxWashNum) 
            return;
        if (other.tag == "Water")
	{
            nowWashNum++;
	    if(Washing == 1) return;
	    else
	    {
		Washing = 1;
		WashingNum++;
	    }
	}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DishDestination" && isClean)
        {
            CleanDishManager.numOfOrganizedDish--;
        }

        if (other.tag == "Water")
	{
            if (nowWashNum >= maxWashNum && !isClean)
                ToBeClean();
	    if(Washing == 0) return;
	    else
	    {
		Washing = 0;
		WashingNum--;
	}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Water")
        {
            accTime += Time.deltaTime;
            if (accTime > delay)
            {
                nowWashNum += (float)(1 / System.Math.Pow(1.2, (float)WashingNum));
                accTime = 0;
            }
            if (nowWashNum >= maxWashNum && !isClean)
                ToBeClean();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
	//When felt on the floor
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
