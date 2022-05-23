using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardLeft : MonoBehaviour
{
    private Transform m_Transform;


    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }


    public void OpenCupboardLeft()
    {
        m_Transform.Rotate(Vector3.up, 90);
    }

    public void CloseCupboardLeft()
    {
        m_Transform.Rotate(Vector3.up, -90);
    }
}
