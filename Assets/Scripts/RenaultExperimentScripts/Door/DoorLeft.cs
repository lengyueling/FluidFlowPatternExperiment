using System.Diagnostics;
using UnityEngine;
using System.Collections;
using DG.Tweening;
public class DoorLeft : MonoBehaviour
{
    private Transform m_Transform;
    public float speed = 2;

    private void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }
    


    public void OpenLeftDoor()
    {
        //m_Transform.Rotate(Vector3.up, 80);
        m_Transform.DOLocalRotate(new Vector3(0, 80, 0), speed);
    }

    public void CloseLeftDoor()
    {
        //m_Transform.Rotate(Vector3.up, -80);
        m_Transform.DOLocalRotate(new Vector3(0, 0, 0), speed);
    }
}
