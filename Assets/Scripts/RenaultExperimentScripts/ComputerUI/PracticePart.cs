using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PracticePart : MonoBehaviour
{
    // Start is called before the first frame update
    private SwitchToComputerInterface m_computer;

    private void Awake()
    {
        m_computer = GameObject.Find("ComputerScreen").GetComponent<SwitchToComputerInterface>();
    }
    void Start()
    {
        
    }
    public void Practice()
    {
        m_computer.ComputerInterfaceToMainScene();
    }
    // Update is called once per frame
   
}
