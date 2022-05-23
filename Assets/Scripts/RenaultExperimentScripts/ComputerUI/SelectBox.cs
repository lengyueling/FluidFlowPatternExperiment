
using System;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]

public class SelectBox : MonoBehaviour

{

    private Dropdown drop;
    private GameObject yuanli;
    private GameObject zhanshi;
    private GameObject lianxi;
    private void Awake()
    {
        drop = this.GetComponent<Dropdown>();

        drop.onValueChanged.AddListener(Change);

        yuanli = GameObject.Find("PrinciplePart");
        zhanshi = GameObject.Find("ExhibitionPart");
        lianxi = GameObject.Find("PracticePart");
    }
    void Start()

    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        init();
    }

    private void init()
    {
        yuanli.SetActive(true);
        zhanshi.SetActive(false);
        lianxi.SetActive(false);
    }
    private void Change(int index)

    {

        Debug.Log(index);

        switch (index)

        {

            case 0:
                yuanli.SetActive(true);
                zhanshi.SetActive(false);
                lianxi.SetActive(false);
                break;

            case 1:
                yuanli.SetActive(false);
                zhanshi.SetActive(true);
                lianxi.SetActive(false);
                break;

            case 2:
                yuanli.SetActive(false);
                zhanshi.SetActive(false);
                lianxi.SetActive(true);
                break;

            default: break;

        }

    }


}
