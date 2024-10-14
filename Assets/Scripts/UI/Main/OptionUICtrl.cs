using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUICtrl : MonoBehaviour
{
    public GameObject[] MenuCtrlGame;
    public GameObject[] MenuCtrlButton;
    public GameObject[] BGMGauge;
    public GameObject[] SDEGauge;

    jsonSaveSoader ManagerGame;

    private void Start()
    {
        ManagerGame = GameObject.Find("Singleton").gameObject.GetComponent<jsonSaveSoader>();
    }
    /*
     * 0 : 게임
     * 1 : 그래픽
     * 2 : 사운드
     * 3 : 계정
     */

    public void GameButtonCtrl(int num)
    {
        ResetButton(num); 
    }

    public void ResetButton(int num)
    {
        for (int i = 0; i < MenuCtrlButton.Length; i++)
        {
            MenuCtrlButton[i].GetComponent<RectTransform>().sizeDelta = new Vector2(275, 150);
            MenuCtrlButton[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-390, 650 - (i * 200));
            MenuCtrlGame[i].SetActive(false);
        }
        MenuCtrlButton[num].GetComponent<RectTransform>().sizeDelta = new Vector2(325, 150);
        MenuCtrlButton[num].GetComponent<RectTransform>().anchoredPosition = new Vector2(-365, 650 - (num * 200));
        MenuCtrlGame[num].SetActive(true);
    }

    public void Language(bool lang)
    {
        if(lang)        //true이면 한국어
        {

        }
        else
        {

        }
    }

    public void SkillUseful(bool useful)
    {
        ManagerGame.JsonData.UI.HowSkill = useful;      //true 더블터치 false 스킬터치
    }

    public void CharacterQuality(int i)
    {
        switch (i)
        {
            case 1:             //저
                ManagerGame.JsonData.UI.CharQual = 1;
                break;
            case 2:             //중
                ManagerGame.JsonData.UI.CharQual = 2;
                break;
            case 3:             //고
                ManagerGame.JsonData.UI.CharQual = 3;
                break;

            default:
                break;
        }
    }

    public void BackgroundQuality(int i)
    {
        switch (i)
        {
            case 1:             //저
                ManagerGame.JsonData.UI.BakcQual = 1;
                break;
            case 2:             //중
                ManagerGame.JsonData.UI.BakcQual = 2;
                break;
            case 3:             //고
                ManagerGame.JsonData.UI.BakcQual = 3;
                break;

            default:
                break;
        }
    }
    public void BgmCtrl(bool check)
    {
        if (check)          //+
        {
            ManagerGame.JsonData.UI.Bgm += 20;
            if (ManagerGame.JsonData.UI.Bgm > 100)
                ManagerGame.JsonData.UI.Bgm = 100;

        }
        else                //-
        {
            ManagerGame.JsonData.UI.Bgm -= 20;
            if (ManagerGame.JsonData.UI.Bgm < 0)
                ManagerGame.JsonData.UI.Bgm = 0;
        }

        GaugeCtrl(BGMGauge, ManagerGame.JsonData.UI.Bgm);
    }

    public void EffmCtrl(bool check)
    {
        if (check)          //+
        {
            ManagerGame.JsonData.UI.Efm += 20;
            if (ManagerGame.JsonData.UI.Efm > 100)
                ManagerGame.JsonData.UI.Efm = 100;
        }
        else                //-
        {
            ManagerGame.JsonData.UI.Efm -= 20;
            if (ManagerGame.JsonData.UI.Efm < 0)
                ManagerGame.JsonData.UI.Efm = 0;
        }

        GaugeCtrl(SDEGauge, ManagerGame.JsonData.UI.Efm);
    }
    
    public void GaugeCtrl(GameObject[] Gauge, int a)
    {
        
        for (int i = 0; i < Gauge.Length; i++)
            Gauge[i].SetActive(false);

        for (int i = 0; i < a / 20; i++)
            Gauge[i].SetActive(true);
    }
}
