using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterButton : MonoBehaviour {
    bool isWaterComeOut;
    public Material onWaterMaterial;
    public Material offWaterMaterial;

    public GameObject[] runningWaters;
    public GameObject[] sinkWaters;

    private void Start()
    {
        isWaterComeOut = false;
        this.GetComponent<MeshRenderer>().material = offWaterMaterial;
    }

    public void SwitchingWaterComeOut()
    {
        if (isWaterComeOut)
        {
            OffWaterComeOut();
            return;
        }
        OnWaterComeOut();
        return;
    }

    void OnWaterComeOut()
    {
        isWaterComeOut = true;
        this.GetComponent<MeshRenderer>().material = onWaterMaterial;
        StartCoroutine("OnRunningWater");
    }

    void OffWaterComeOut()
    {
        isWaterComeOut = false;
        this.GetComponent<MeshRenderer>().material = offWaterMaterial;
        StartCoroutine("OffRunningWater");
    }

    IEnumerator OnRunningWater()
    {
        if (!isWaterComeOut) yield return null;
        for(int i = 0; i < 12; i++)
        {
            runningWaters[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        for(int i = 0; i < 4; i++)
        {
            sinkWaters[i].SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator OffRunningWater()
    {
        if (isWaterComeOut) yield return null;
        for (int i = 0; i < 12; i++)
        {
            runningWaters[i].SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 3; i >= 0; i--)
        {
            sinkWaters[i].SetActive(false);
            yield return new WaitForSeconds(2f);
        }
    }
}
