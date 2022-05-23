using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveControl : MonoBehaviour
{
    private Transform m_Transform;
    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenValve()
    {
        m_Transform.Rotate(Vector3.up, -90);
    }
}
