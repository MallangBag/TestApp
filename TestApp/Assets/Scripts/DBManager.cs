using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    //�̱���
    private static DBManager instance;
    
    //Find
    public string find1 = "FIND1";
    public string find2 = "FIND2";
    
    [SerializeField]
    private Toggle[] titleToggles;
    [SerializeField]
    private Toggle[] optionToggles;
    private string[] titleToggleNames;
    private string[] optionToggleNames;
    
    //�����; �� �����°� Ȯ�� / PressButton.cs�� ����
    private bool isClick;

    #region get-set
    public Toggle[] Title
    {
        get { return titleToggles; }
        set { titleToggles = value; }
    }
    public Toggle[] Option
    {
        get { return optionToggles; }
        set { optionToggles = value; }
    }

    public string[] Title_Names
    {
        get { return titleToggleNames; }
    }
    public string[] Option_Names
    {
        get { return optionToggleNames; }
    }

    public bool IsClick
    {
        get { return isClick; }
        set { isClick = value; }
    }
    #endregion

    //�̱���
    public static DBManager Instance
    {
        get
        {
            //�ν��Ͻ��� ���� ��� ����
            if (instance == null)
            {
                instance = FindObjectOfType<DBManager>();

                //���� ���� ��� ���� ����
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(DBManager).Name);
                    instance = singletonObject.AddComponent<DBManager>();
                }
            }
            return instance;
        }
    }


    //���� �ʱ�ȭ
    private void InitializeSettings()
    {
        FindTitle();
        FindOption();
        isClick = false;
    }
    private void FindTitle()
    {
        if (GameObject.Find(find1) != null)
        {
            Transform obj = GameObject.Find(find1).transform;
            titleToggles = new Toggle[obj.childCount];
            for (int i = 0; i < obj.childCount; i++)
            {
                titleToggles[i] = obj.GetChild(i).GetComponent<Toggle>();
            }
            NamingTitle();
        }
        else
        {
            Debug.Log("error: FIND1 MISSING");
        }
    }
    void FindOption()
    {
        if (GameObject.Find(find2) != null)
        {
            Transform obj = GameObject.Find(find2).transform;
            optionToggles = new Toggle[obj.childCount];
            for (int i = 0; i < obj.childCount; i++)
            {
                optionToggles[i] = obj.GetChild(i).GetComponent<Toggle>();
            }
            NamingOption();
            obj.parent.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("error: FIND2 MISSING");
        }

    }

    private void NamingTitle()
    {
        titleToggleNames = new string[titleToggles.Length];
        for (int i = 0; i < titleToggles.Length; i++)
        {
            titleToggleNames[i] = titleToggles[i].name;
        }
    }

    private void NamingOption()
    {
        optionToggleNames = new string[optionToggles.Length];
        for (int i = 0; i < optionToggles.Length; i++)
        {
            optionToggleNames[i] = optionToggles[i].name;
        }
    }

    // �̱��� ������Ʈ�� �ʱ�ȭ
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            InitializeSettings(); //���� �ʱ�ȭ
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
