using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    //Select All_변수
    [SerializeField]
    Toggle[] toggleArr;
    //OptionPanel_변수
    [SerializeField]
    GameObject optionPanel;


    //메인 화면으로 넘어가기
    public void MainSceneLoad()
    {
        SceneLoader.Instance.LoadScene("Main");
    }

    //버튼 누르면 해당 토글 전부 켜기
    public void SelectAll()
    {
        for (int i = 0; i < 10; i++)
        {
            toggleArr[i].GetComponent<Toggle>().isOn = true;
        }
    }

    //옵션창 열기
    public void OptionPanelOpen()
    {
        optionPanel.SetActive(true);
    }
    //옵션창 닫기
    public void OptionPanelClose()
    {
        optionPanel.SetActive(false);
    }


    //앱 종료
    public void QuitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
