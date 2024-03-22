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


    private void Start()
    {
        this.GetComponent<Toggle>().onValueChanged.AddListener(delegate { OnToggleChanged(); });
    }

    public void OnToggleChanged()
    {
        if(this.GetComponent<Toggle>().isOn)
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
