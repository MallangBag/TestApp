using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField]
    GameObject optionPanel;


    DBManager dBManager;
    

    private void Start()
    {
        dBManager = DBManager.Instance;
        LoadOption();
    }

    public void LoadOption()
    {
        for (int i = 0; i < dBManager.Option.Length; i++)
        {

            if (PlayerPrefs.GetInt(dBManager.Option_Names[i]) != 0)  //완전 처음이면 아니면
            {
                //1이면 true 0이면 false
                if (PlayerPrefs.GetInt(dBManager.Option_Names[i]) == CONST.TRUE)
                {
                    dBManager.Option[i].isOn =true;
                }
                else
                {
                    dBManager.Option[i].isOn = false;
                }
            }
            else
            {
                dBManager.Option[i].isOn = true;
            }
        }
    }

    //옵션창 열기
    public void OptionPanelOpen()
    {
        optionPanel.SetActive(true);
        LoadOption();
    }

    //옵션창 닫기
    public void OptionPanelClose()
    {
        SaveOption();
        optionPanel.SetActive(false);
    }

    public void SaveOption()
    {
        for (int i = 0; i < dBManager.Option.Length; i++)
        {
            //토글 상태 보고 1 또는 -1으로 저장 //0은 초기값
            if (dBManager.Option[i].isOn == true)
            {
                PlayerPrefs.SetInt(dBManager.Option_Names[i], CONST.TRUE);
            }
            else
            {
                PlayerPrefs.SetInt(dBManager.Option_Names[i], CONST.FALSE);
            }
        }
    }

    //설정 초기화
    public void DeleteAllOption()
    {
        for (int i = 0; i < dBManager.Option.Length; i++)
        {
            PlayerPrefs.DeleteAll();
        }

    }

    //버튼 누르면 해당 토글 전부 켜기
    public void SelectAll()
    {
        for (int i = 0; i < 10; i++)
        {
            dBManager.Option[i].isOn = true;
        }
    }

}
