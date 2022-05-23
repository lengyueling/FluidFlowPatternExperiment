using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseControl : MonoBehaviour
{
    private Transform m_Transform;

    private void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }


    public void OpenDoor()
    {
        m_Transform.Rotate(Vector3.up, 100);
    }
    public void CloseDoor()
    {
        m_Transform.Rotate(Vector3.up, -100);
    }
}
