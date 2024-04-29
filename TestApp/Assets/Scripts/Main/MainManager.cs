using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainManager : MonoBehaviour
{
    //Title 정보 가져오기 및 저장
    private DBManager dBManager;
    [SerializeField]
    private List<string> titleToggleNames;
    [SerializeField]
    private List<string> optionToggleNames;

    //파싱
    List<Dictionary<string, object>> data_Dialog;

    //문제 만들기
    //문제 뽑기 (랜덤)
    int randomOption;
    int randomNum;
    int randomTitle;
    //문제
    [SerializeField]
    private TextMeshProUGUI textQuestion;
    //답
    [SerializeField]
    private GameObject mcObj;
    [SerializeField]
    private GameObject saObj;


    private void Start()
    {
        LoadNames();
        Making();
    }
    private void InitializeSettings()
    {

    }

    private void LoadNames()
    {
        dBManager = DBManager.Instance;
        titleToggleNames = new List<string>();
        optionToggleNames = new List<string>();

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
    private void Making()
    {
        randomOption = Random.Range(0, optionToggleNames.Count);    //문제 항목 랜덤
        randomTitle = Random.Range(0, titleToggleNames.Count);      //문제 유형 랜덤
        if (Resources.Load("csv/" + optionToggleNames[randomOption] + "_" + titleToggleNames[randomTitle]) != null)
        {
            data_Dialog = CSVReader.Read(optionToggleNames[randomOption] + "_" + titleToggleNames[randomTitle]);
            randomNum = Random.Range(0, data_Dialog.Count);
        }

        Question();
        Answer();
    }

    //문제 생성
    private void Question()
    {
        textQuestion.text = data_Dialog[randomNum][CONST.QUESTION].ToString();
    }
    //정답 생성
    private void Answer()
    {
        switch (titleToggleNames[randomTitle])
        {
            case CONST.MC:
                mcObj.SetActive(true);
                break;
            case CONST.SA:
                saObj.SetActive(true);
                break;
            default:
                break;
        }
    }
    //코멘트 생성
    private void Comment()
    {

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
