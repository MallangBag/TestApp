using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    //Select All_����
    [SerializeField]
    Toggle[] toggleArr;
    //OptionPanel_����
    [SerializeField]
    GameObject optionPanel;


    //���� ȭ������ �Ѿ��
    public void MainSceneLoad()
    {
        SceneLoader.Instance.LoadScene("Main");
    }

    //��ư ������ �ش� ��� ���� �ѱ�
    public void SelectAll()
    {
        for (int i = 0; i < 10; i++)
        {
            toggleArr[i].GetComponent<Toggle>().isOn = true;
        }
    }

    //�ɼ�â ����
    public void OptionPanelOpen()
    {
        optionPanel.SetActive(true);
    }
    //�ɼ�â �ݱ�
    public void OptionPanelClose()
    {
        optionPanel.SetActive(false);
    }


    //�� ����
    public void QuitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
