using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosition : MonoBehaviour {
    Vector3 originPosition;
    Vector3 originRotation;

    void Start()
    {
        originPosition = transform.position;
        originRotation = transform.forward;
    }
	
	public void StartFixedTransform()
    {
        StartCoroutine("SetOriginPosition");
        StartCoroutine("SetOriginRotation");
    }
    public void StopFixedTransform()
    {
        StopCoroutine("SetOriginPosition");
        StopCoroutine("SetOriginRotation");
    }

    IEnumerator SetOriginPosition()
    {
        while (true)
        {
            transform.position = originPosition;
            yield return null;
        }
    }

    IEnumerator SetOriginRotation()
    {
        while (true)
        {
            transform.eulerAngles = originRotation;
            yield return null;
        }
    }
}
