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

            if (PlayerPrefs.GetInt(dBManager.Option_Names[i]) != 0)  //���� ó���̸� �ƴϸ�
            {
                //1�̸� true 0�̸� false
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

    //�ɼ�â ����
    public void OptionPanelOpen()
    {
        optionPanel.SetActive(true);
        LoadOption();
    }

    //�ɼ�â �ݱ�
    public void OptionPanelClose()
    {
        SaveOption();
        optionPanel.SetActive(false);
    }

    public void SaveOption()
    {
        for (int i = 0; i < dBManager.Option.Length; i++)
        {
            //��� ���� ���� 1 �Ǵ� -1���� ���� //0�� �ʱⰪ
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

    //���� �ʱ�ȭ
    public void DeleteAllOption()
    {
        for (int i = 0; i < dBManager.Option.Length; i++)
        {
            PlayerPrefs.DeleteAll();
        }

    }

    //��ư ������ �ش� ��� ���� �ѱ�
    public void SelectAll()
    {
        for (int i = 0; i < 10; i++)
        {
            dBManager.Option[i].isOn = true;
        }
    }

}
