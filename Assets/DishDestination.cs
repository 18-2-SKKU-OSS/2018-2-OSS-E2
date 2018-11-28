using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishDestination : MonoBehaviour {
    private float alpha = 0f;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = new Color(1, 1, 0, alpha);
    }

    public IEnumerator Twinkling()
    {
        float changeAlpha = 0.01f;
        while (true)
        {
            yield return new WaitForSeconds(0.0001f);
            if (alpha >= 0.8f || alpha < 0f)
                changeAlpha *= -1;
            alpha += changeAlpha;
            GetComponent<MeshRenderer>().material.color = new Color(1, 1, 0, alpha);
        }
    }
}
