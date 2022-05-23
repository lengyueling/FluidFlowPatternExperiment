using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    public GameObject[] m_lamp;
    public Material[] m_Materials;
    private Light[] m_light;
    private Transform m_Transform;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Z))
        {
            TurnOffdLight();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            TurnOnLight();
        }

    }
    public void TurnOnLight()
    {
        //m_Transform.Rotate(Vector3.right,10);
        for (int i = 0; i < m_lamp.Length; i++)
        {
            
            for (int k = 3;k < 6; k++)
            {
                m_lamp[i].transform.GetChild(k).GetComponent<MeshRenderer>().material = m_Materials[0];
            }
            
            for (int j = 0; j < 3;j++ )
            {
                m_lamp[i].transform.GetChild(j).GetComponent<Light>().enabled = true;
            }
        }
    }

    public void TurnOffdLight()
    {

        //m_Transform.Rotate(Vector3.up, -10);
        for (int i = 0; i < m_lamp.Length; i++)
        {
            
            for (int k = 3;k < 6; k++)
            {
                m_lamp[i].transform.GetChild(k).GetComponent<MeshRenderer>().material = m_Materials[1];
            }
            
            for (int j = 0; j < 3; j++ )
            {
                m_lamp[i].transform.GetChild(j).GetComponent<Light>().enabled = false;
            }
        }
        
    }
}
