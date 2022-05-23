
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using System.Net.Mime;
using System.Diagnostics;
public class ConfigurationUI : MonoBehaviour
{
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController player_fps;
    private GameObject conUI;
    private GameObject MidPoint;
    //private FirstPersonController computer;
    private void Awake()
    {
        player_fps = GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        conUI = GameObject.Find("ConfigurationInterfaceUI");
        MidPoint = GameObject.Find("MidPoint");

    }
    // Start is called before the first frame update
    void Start()
    {
        //player_fps.enabled = true;
        conUI.SetActive(false);
    }

    public void SwitchToConUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player_fps.enabled = false;
        conUI.SetActive(true);
        MidPoint.SetActive(false);
    }

    public void ConInterfaceToMainScene()
    {
        player_fps.enabled = true;
        conUI.SetActive(false);
        MidPoint.SetActive(true);
    }

    
}