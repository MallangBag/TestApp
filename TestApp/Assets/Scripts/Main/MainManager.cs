using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private OptionManager optionManager;
    private TitleManager titleManager;
    private string[] titleToggleNames;
    private string[] optionToggleNames;

    //csv 파싱으로 question 가져오기
    private void Start()
    {
        //LoadNames();
        //MakeQuestion();
    }

    private void LoadNames()
    {
        //for (int i = 0; i < CONST.TITLE_MAX; i++)
        //{
        //    if (PlayerPrefs.GetInt(titleManager.TitleToggleNames[i]) == CONST.TRUE)
        //    {
        //        titleToggleNames = titleManager.TitleToggleNames;
        //    }
        //    else
        //    {
        //        titleToggleNames = null;
        //    }
        //}
        //for (int i = 0; i < CONST.OPTION_MAX; i++)
        //{
        //    if (PlayerPrefs.GetInt(optionManager.OptionToggleNames[i]) == 1)
        //    {
        //        optionToggleNames = optionManager.OptionToggleNames;
        //    }
        //    else
        //    {
        //        optionToggleNames = null;
        //    }
        //}
    }

    //
    private void MakeQuestion()
    {
    }

    public void CSVLoad()
    {

    //    for (int i = 0; i < CONST.TITLE_MAX; i++)
    //    {
    //        if(titleToggleNames[i] != null)
    //        {
    //            for (int j = 0; j < optionToggleNames.Length; j++)
    //            {
    //                if(optionToggleNames[i] != null)
    //                {
    //                    Debug.Log(titleToggleNames[i] +" " + optionToggleNames[i]);
    //                    List<Dictionary<string, object>> data_Dialog = CSVReader.Read(titleToggleNames[i] + "_" + optionToggleNames[i]);
    //                    print(data_Dialog[i]["question"].ToString());
    //                }
    //            }
    //        }

    //    }
    }

}
