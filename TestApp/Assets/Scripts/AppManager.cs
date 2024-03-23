using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    //csv 파싱으로 question 가져오기
    private void Start()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("comvenience_mc");

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            print(data_Dialog[i]["question"].ToString());
        }
    }
}
