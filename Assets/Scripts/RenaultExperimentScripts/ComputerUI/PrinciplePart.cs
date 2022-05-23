
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PrinciplePart : MonoBehaviour
{
    private GameObject jieshao;
    private GameObject yuanli;
    private GameObject wenda;
    private GameObject buzhou;
    private GameObject mudi;

    private void Awake()
    {
        jieshao = GameObject.Find("introduce_text");
        yuanli = GameObject.Find("principle_text");
        wenda = GameObject.Find("questions_text");
        buzhou = GameObject.Find("procedure_text");
        mudi = GameObject.Find("purpose_text");
    }
    void Start()
    {
        
        SetActive(jieshao, false);
        SetActive(yuanli, false);
        SetActive(wenda, false);
        SetActive(buzhou, false);
        SetActive(mudi, false);
        //SetActive(jieshao, false);
        //SetActive(yuanli, false);
        //SetActive(wenda, false);
        //SetActive(buzhou, false);
        //SetActive(mudi, false);
        //init();
    }
    private void init()
    {
        SetActive(jieshao, false);
        SetActive(yuanli, false);
        SetActive(wenda, false);
        SetActive(buzhou, false);
        SetActive(mudi, false);
        //jieshao.SetActive(false);
        //yuanli.SetActive(false);
        //wenda.SetActive(false);
        //buzhou.SetActive(false);
        //mudi.SetActive(false);
        print(123);
    }

    public void Jieshao()
    {
        SetActive(jieshao, true);
        SetActive(yuanli, false);
        SetActive(wenda, false);
        SetActive(buzhou, false);
        SetActive(mudi, false);
    }
    public void Wenda()
    {
        SetActive(jieshao, false);
        SetActive(yuanli, false);
        SetActive(wenda, true);
        SetActive(buzhou, false);
        SetActive(mudi, false);
    }
    public void Mudi()
    {
        SetActive(jieshao, false);
        SetActive(yuanli, false);
        SetActive(wenda, false);
        SetActive(buzhou, false);
        SetActive(mudi, true);
    }
    public void Buzhou()
    {
        SetActive(jieshao, false);
        SetActive(yuanli, false);
        SetActive(wenda, false);
        SetActive(buzhou, true);
        SetActive(mudi, false);
    }
    public void Yuanli()
    {
        SetActive(jieshao, false);
        SetActive(yuanli, true);
        SetActive(wenda, false);
        SetActive(buzhou, false);
        SetActive(mudi, false);
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
