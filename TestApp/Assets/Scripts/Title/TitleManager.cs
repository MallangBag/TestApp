using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    //�� �Ѿ�� ��ư, ��۵� �۵� �ȵǰ� �ϴ� ����
    [SerializeField]
    private Toggle[] toggles;
    [SerializeField]
    private Button[] buttons;

    //DB ����
    DBManager dBManager;

    private void Start()
    {
        dBManager = DBManager.Instance;
        LoadTitle();
    }

    public void SaveTitle()
    {
        for (int i = 0; i < dBManager.Title.Length; i++)
        {
            //��� ���� ���� 1 �Ǵ� -1���� ���� //0�� �ʱⰪ
            if (toggles[i].isOn == true)
            {
                PlayerPrefs.SetInt(dBManager.Title_Names[i], CONST.TRUE);
            }
            else
            {
                PlayerPrefs.SetInt(dBManager.Title_Names[i], CONST.FALSE);
            }
        }
    }

    public void LoadTitle()
    {
        string[] TitleName = dBManager.Title_Names;
        for (int i = 0; i < dBManager.Title.Length; i++)
        {
            //���� ó���� �ƴϸ� ���� �״� ��� ON/OFF
            if (PlayerPrefs.GetInt(TitleName[i]) != 0)
            {
                //1�̸� true 0�̸� false
                if (PlayerPrefs.GetInt(TitleName[i]) == CONST.TRUE)
                {
                    dBManager.Title[i].isOn = true;
                }
                else
                {
                    dBManager.Title[i].isOn = false;
                }
            }
            //���� ó���̸� ���� ON
            else
            {
                dBManager.Title[i].isOn = true;
            }
        }
    }

    //���� ȭ������ �Ѿ��
    public void MainSceneLoad()
    {
        //�� �Ѿ�� ��ư, ��۵� �۵� �ȵǰ� ��
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        foreach (Toggle toggle in toggles)
        {
            toggle.interactable = false;
        }
        SaveTitle();
        SceneLoader.Instance.LoadScene("Main");
    }

    //�� ����
    public void QuitApp()
    {
        //SaveTitle();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}
