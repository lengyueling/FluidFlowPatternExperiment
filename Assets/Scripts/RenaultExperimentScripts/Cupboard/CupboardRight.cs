using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardRight : MonoBehaviour
{
    private Transform m_Transform;


    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }


    public void OpenCupboardRight()
    {
        m_Transform.Rotate(Vector3.up, -90);
        //print(3);

    }

    public void CloseCupboardRight()
    {
        m_Transform.Rotate(Vector3.up, 90);
        //print(4);
    }
}

