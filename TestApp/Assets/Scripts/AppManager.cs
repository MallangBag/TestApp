using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    //csv �Ľ����� question ��������
    private void Start()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("comvenience_mc");

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            print(data_Dialog[i]["question"].ToString());
        }
    }
}
