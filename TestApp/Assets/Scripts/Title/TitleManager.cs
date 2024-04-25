using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    //씬 넘어갈때 버튼, 토글들 작동 안되게 하는 변수
    [SerializeField]
    private Toggle[] toggles;
    [SerializeField]
    private Button[] buttons;

    //DB 변수
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
            //토글 상태 보고 1 또는 -1으로 저장 //0은 초기값
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
            //완전 처음이 아니면 전에 켰던 대로 ON/OFF
            if (PlayerPrefs.GetInt(TitleName[i]) != 0)
            {
                //1이면 true 0이면 false
                if (PlayerPrefs.GetInt(TitleName[i]) == CONST.TRUE)
                {
                    dBManager.Title[i].isOn = true;
                }
                else
                {
                    dBManager.Title[i].isOn = false;
                }
            }
            //완전 처음이면 전부 ON
            else
            {
                dBManager.Title[i].isOn = true;
            }
        }
    }

    //메인 화면으로 넘어가기
    public void MainSceneLoad()
    {
        //씬 넘어갈때 버튼, 토글들 작동 안되게 함
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

    //앱 종료
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
