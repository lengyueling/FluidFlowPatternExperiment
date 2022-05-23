using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using System.Net.Mime;
using System.Diagnostics;
public class SwitchToComputerInterface : MonoBehaviour
{
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController player_fps;
    private GameObject computer_ui;
    private GameObject MidPoint;
    //private FirstPersonController computer;
    private void Awake()
    {
        player_fps = GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        computer_ui = GameObject.Find("ComputerInterfaceUI");
        MidPoint = GameObject.Find("MidPoint");

    }
    // Start is called before the first frame update
    void Start()
    {
        player_fps.enabled = true;
        computer_ui.SetActive(false);
    }

    public void SwitchToComputerUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player_fps.enabled = false;
        computer_ui.SetActive(true);
        MidPoint.SetActive(false);
    }

    public void ComputerInterfaceToMainScene()
    {
        player_fps.enabled = true;
        computer_ui.SetActive(false);
        MidPoint.SetActive(true);
    }
}
