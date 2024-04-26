using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainManager : MonoBehaviour
{
    private DBManager dBManager;
    [SerializeField]
    private List<string> titleToggleNames;
    [SerializeField]
    private List<string> optionToggleNames;

    List<Dictionary<string, object>> data_Dialog;

    //csv 파싱으로 question 가져오기
    private void Start()
    {
        dBManager = DBManager.Instance;
        titleToggleNames = new List<string>();
        optionToggleNames = new List<string>();
        data_Dialog = new List<Dictionary<string, object>>();
        
        LoadNames();
        MakeQuestion();
    }

    private void LoadNames()
    {
        Debug.Log(dBManager.Title_Names.Length);
        for (int i = 0; i < dBManager.Title_Names.Length; i++)
        {
            if (PlayerPrefs.GetInt(dBManager.Title_Names[i]) == CONST.TRUE)
            {
                titleToggleNames.Add(dBManager.Title_Names[i]);
            }
        }
        for (int i = 0; i < dBManager.Option_Names.Length; i++)
        {
            if (PlayerPrefs.GetInt(dBManager.Option_Names[i]) == CONST.TRUE)
            {
                optionToggleNames.Add(dBManager.Option_Names[i]);
            }
        }
    }

    //메인 화면 보이게 함
    private void MakeQuestion()
    {
        int optionRandom = Random.Range(0, optionToggleNames.Count - 1);    //문제 항목 랜덤
        int titleRandom = Random.Range(0, titleToggleNames.Count - 1);      //문제 유형 랜덤
        int numRandom = 0;
        while(true)
        {
            if (Resources.Load("csv/" + optionToggleNames[optionRandom] + "_" + titleToggleNames[titleRandom]) != null)
            {
                numRandom = Random.Range(1, data_Dialog.Count);
                print(data_Dialog[numRandom]["question"].ToString());
                break;
            }
        }
    }
    #region 예시용 CSVLoad
    public void CSVLoad()
    {
        for (int i = 0; i < titleToggleNames.Count; i++)
        {
            if (titleToggleNames[i] != null)
            {
                for (int j = 0; j < optionToggleNames.Count; j++)
                {
                    if (optionToggleNames[j] != null)
                    {
                        if (Resources.Load("csv/" + optionToggleNames[j] + "_" + titleToggleNames[i]) != null)
                        {
                            Debug.Log(optionToggleNames[j] + "_" + titleToggleNames[i] + "; Load함");
                            data_Dialog = CSVReader.Read(optionToggleNames[j] + "_" + titleToggleNames[i]);
                            MakeQuestion();
                        }
                        else
                        {
                            Debug.Log(optionToggleNames[j] + "_" + titleToggleNames[i] + "; 없는 파일 입니다.");
                        }
                    }
                }
            }
        }
    }
    #endregion

}
