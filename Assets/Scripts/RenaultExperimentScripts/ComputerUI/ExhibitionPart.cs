using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhibitionPart : MonoBehaviour
{
    private GameObject shiyan;
    private GameObject shebei;
    private GameObject cengliu1;
    private GameObject cengliu2;
    private GameObject cengliu3;
    private GameObject tuanliu;
    private GameObject shiyanB;
    private GameObject shebeiB;
    private GameObject cengliuButton;
    private GameObject cengliu1B;
    private GameObject cengliu2B;
    private GameObject cengliu3B;
    private GameObject tuanliuB;
    private GameObject fanhuiB;


    private void Awake()
    {
        shiyan = GameObject.Find("实验演示视频");
        shebei = GameObject.Find("设备演示");
        cengliu1 = GameObject.Find("层流_片层1");
        cengliu2 = GameObject.Find("层流_片层2");
        cengliu3 = GameObject.Find("层流_环形");
        tuanliu = GameObject.Find("湍流");
        shiyanB = GameObject.Find("experimental_demo_button");
        shebeiB = GameObject.Find("equipment_demo_button");
        cengliuButton = GameObject.Find("laminar_flow_domo_button"); 
         cengliu1B = GameObject.Find("lamella_2_button");
        cengliu2B = GameObject.Find("annular_button");
        cengliu3B = GameObject.Find("lamella_1_button");
        tuanliuB = GameObject.Find("turbulent_flow_domo_button");
        fanhuiB = GameObject.Find("return_button");
    }

    private void Start()
    {
        SetActive(shiyan, false);
        SetActive(shebei, false);
        SetActive(cengliu1, false);
        SetActive(cengliu2, false);
        SetActive(cengliu3, false);
        SetActive(tuanliu, false);
        SetActive(shiyanB, true);
        SetActive(shebeiB, true);
        SetActive(cengliuButton, true);
        SetActive(cengliu1B, false);
        SetActive(cengliu2B, false);
        SetActive(cengliu3B, false);
        SetActive(tuanliuB, true);
        SetActive(fanhuiB, false);
    }
    public void Shiyan()
    {
        SetActive(shiyan, true);
        SetActive(shebei, false);
        SetActive(cengliu1, false);
        SetActive(cengliu2, false);
        SetActive(cengliu3, false);
        SetActive(tuanliu, false);
        SetActive(shiyanB, false);
        SetActive(shebeiB, false);
        SetActive(cengliuButton, false);
        SetActive(cengliu1B, false);
        SetActive(cengliu2B, false);
        SetActive(cengliu3B, false);
        SetActive(tuanliuB, false);
        SetActive(fanhuiB, true);

        
    }
    public void Shebei()
    {
        SetActive(shiyan, false);
        SetActive(shebei, true);
        SetActive(cengliu1, false);
        SetActive(cengliu2, false);
        SetActive(cengliu3, false);
        SetActive(tuanliu, false);
        SetActive(shiyanB, false);
        SetActive(shebeiB, false);
        SetActive(cengliuButton, false);
        SetActive(cengliu1B, false);
        SetActive(cengliu2B, false);
        SetActive(cengliu3B, false);
        SetActive(tuanliuB, false);
        SetActive(fanhuiB, true);

        
    }
    public void Cengliu()
    {
        SetActive(shiyan, false);
        SetActive(shebei, false);
        SetActive(cengliu1, false);
        SetActive(cengliu2, false);
        SetActive(cengliu3, false);
        SetActive(tuanliu, false);
        SetActive(shiyanB, false);
        SetActive(shebeiB, false);
        SetActive(cengliuButton, false);
        SetActive(cengliu1B, true);
        SetActive(cengliu2B, true);
        SetActive(cengliu3B, true);
        SetActive(tuanliuB, false);
        SetActive(fanhuiB, true);

        
    }
    public void Tuanliu()
    {
        SetActive(shiyan, false);
        SetActive(shebei, false);
        SetActive(cengliu1, false);
        SetActive(cengliu2, false);
        SetActive(cengliu3, false);
        SetActive(tuanliu, true);
        SetActive(shiyanB, false);
        SetActive(shebeiB, false);
        SetActive(cengliuButton, false);
        SetActive(cengliu1B, false);
        SetActive(cengliu2B, false);
        SetActive(cengliu3B, false);
        SetActive(tuanliuB, false);
        SetActive(fanhuiB, true);

        
    }
    public void Fanhui()
    {
        SetActive(shiyan, false);
        SetActive(shebei, false);
        SetActive(cengliu1, false);
        SetActive(cengliu2, false);
        SetActive(cengliu3, false);
        SetActive(tuanliu, false);
        SetActive(shiyanB, true);
        SetActive(shebeiB, true);
        SetActive(cengliuButton, true);
        SetActive(cengliu1B, false);
        SetActive(cengliu2B, false);
        SetActive(cengliu3B, false);
        SetActive(tuanliuB, true);
        SetActive(fanhuiB, false);

    }

    public void Cengliu1B()
    {
        SetActive(shiyan, false);
        SetActive(shebei, false);
        SetActive(cengliu1, true);
        SetActive(cengliu2, false);
        SetActive(cengliu3, false);
        SetActive(tuanliu, false);
        SetActive(shiyanB, false);
        SetActive(shebeiB, false);
        SetActive(cengliuButton, false);
        SetActive(cengliu1B, false);
        SetActive(cengliu2B, false);
        SetActive(cengliu3B, false);
        SetActive(tuanliuB, false);
        SetActive(fanhuiB, true);

        
    }
    public void Cengliu2B()
    {
        SetActive(shiyan, false);
        SetActive(shebei, false);
        SetActive(cengliu1, false);
        SetActive(cengliu2, true);
        SetActive(cengliu3, false);
        SetActive(tuanliu, false);
        SetActive(shiyanB, false);
        SetActive(shebeiB, false);
        SetActive(cengliuButton, false);
        SetActive(cengliu1B, false);
        SetActive(cengliu2B, false);
        SetActive(cengliu3B, false);
        SetActive(tuanliuB, false);
        SetActive(fanhuiB, true);

        
    }
    public void Cengliu3B()
    {
        SetActive(shiyan, false);
        SetActive(shebei, false);
        SetActive(cengliu1, false);
        SetActive(cengliu2, false);
        SetActive(cengliu3, true);
        SetActive(tuanliu, false);
        SetActive(shiyanB, false);
        SetActive(shebeiB, false);
        SetActive(cengliuButton, false);
        SetActive(cengliu1B, false);
        SetActive(cengliu2B, false);
        SetActive(cengliu3B, false);
        SetActive(tuanliuB, false);
        SetActive(fanhuiB, true);

        
    }

    static public void SetActive(GameObject go, bool state)
    {
        if (go == null)
        {
            print("这是空啊");
            return;
        }

        if (go.activeSelf != state)
        {
            go.SetActive(state);
            print("成功执行");
        }
    }
}
