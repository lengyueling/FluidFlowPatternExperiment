using System.Diagnostics;
using UnityEngine;
using System.Collections;
using DG.Tweening;
public class DoorRight : MonoBehaviour {

	private Transform m_Transform;
	//public float RotateSpeed = 10f;
	public float speed = 2;

	void Awake () {
		m_Transform = gameObject.GetComponent<Transform> ();
	}
	

	public void OpenRightDoor()
	{
        //m_Transform.Rotate(Vector3.up, -80);
		m_Transform.DOLocalRotate(new Vector3(0, -80, 0), speed);
	}

	public void CloseRightDoor()
	{
		//m_Transform.Rotate (Vector3.up, 80);
		m_Transform.DOLocalRotate(new Vector3(0, 0, 0), speed);
	}
}
