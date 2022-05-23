using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    private bool b = true;
    
    public GameObject testObj;
    public GameObject entirety;
    private MovePivot wjx;
    private MovePivot wjz;

    private void Start()
    {               
        wjx = testObj.GetComponent<MovePivot>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (b)
            {
                if (wjx != null)
                    wjx.Start();
                if (wjz != null)
                    wjz.Start();
                b = false;
            }
        }
    }            
    
}
