using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleToggleOnOff : MonoBehaviour
{
    [SerializeField]
    public Image background;
    public TextMeshProUGUI text;
    Toggle toggle;    

    private void Start()
    {
        //ó�� isOn�� ���¸� ������ (���� ���� ���� �Ͽ� OnToggleChanged�� �ݿ�)
        toggle = GetComponent<Toggle>();
        OnToggleChanged(toggle.isOn);
        this.GetComponent<Toggle>().onValueChanged.AddListener(delegate { OnToggleChanged(toggle.isOn); });
    }

    public void OnToggleChanged(bool isOn)
    {
        if(isOn)
        {
            background.GetComponent<Image>().color = Color.white;
            text.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        else
        {
            background.GetComponent<Image>().color = Color.black;
            text.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
}
