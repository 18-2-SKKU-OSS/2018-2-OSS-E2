using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour {
    public int trash_inner = 0;
    int current_trash = 0;
    public int maxInner = 5;
    public TrashManager ts;
    bool isEmptyRun = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (trash_inner == 0 && !isEmptyRun)
        {
            isEmptyRun = true;
        }
        if (ts.autoEmpty && !ts.powerEmpty&& trash_inner > 0&&isEmptyRun)
        {   
            StartCoroutine(EmptyTC());
            isEmptyRun = false;
        }
        if(ts.autoEmpty && ts.powerEmpty)
        {
            trash_inner = 0;
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trash")
        {
            if (trash_inner < maxInner)
            {
                trash_inner++;
                ts.current_trash++;
                StartCoroutine(WaitDest(other.gameObject));
            }
            else
            {
            }
        }
        
    }
    IEnumerator WaitDest(GameObject obj)
    {
        yield return new WaitForSeconds(0.001f);
        Destroy(obj);
    }
    IEnumerator EmptyTC()
    {
        trash_inner--;
        yield return new WaitForSeconds(ts.emptySpeed);
        if (trash_inner > 0)
        {
            StartCoroutine(EmptyTC());
        }
        
    }
}
