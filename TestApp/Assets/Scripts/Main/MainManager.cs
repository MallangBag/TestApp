using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainManager : MonoBehaviour
{
    //Title ���� �������� �� ����
    private DBManager dBManager;
    [SerializeField]
    private List<string> titleToggleNames;
    [SerializeField]
    private List<string> optionToggleNames;

    //�Ľ�
    List<Dictionary<string, object>> data_Dialog;

    //���� �����
    //���� �̱� (����)
    int randomOption;
    int randomNum;
    int randomTitle;
    //����
    [SerializeField]
    private TextMeshProUGUI textQuestion;
    //��
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

    //���� ȭ�� ���̰� ��
    private void Making()
    {
        randomOption = Random.Range(0, optionToggleNames.Count);    //���� �׸� ����
        randomTitle = Random.Range(0, titleToggleNames.Count);      //���� ���� ����
        if (Resources.Load("csv/" + optionToggleNames[randomOption] + "_" + titleToggleNames[randomTitle]) != null)
        {
            data_Dialog = CSVReader.Read(optionToggleNames[randomOption] + "_" + titleToggleNames[randomTitle]);
            randomNum = Random.Range(0, data_Dialog.Count);
        }

        Question();
        Answer();
    }

    //���� ����
    private void Question()
    {
        textQuestion.text = data_Dialog[randomNum][CONST.QUESTION].ToString();
    }
    //���� ����
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
    //�ڸ�Ʈ ����
    private void Comment()
    {

    }

    #region ���ÿ� CSVLoad
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
                            Debug.Log(optionToggleNames[j] + "_" + titleToggleNames[i] + "; Load��");
                            data_Dialog = CSVReader.Read(optionToggleNames[j] + "_" + titleToggleNames[i]);
                        }
                        else
                        {
                            Debug.Log(optionToggleNames[j] + "_" + titleToggleNames[i] + "; ���� ���� �Դϴ�.");
                        }
                    }
                }
            }
        }
    }
    #endregion

}
