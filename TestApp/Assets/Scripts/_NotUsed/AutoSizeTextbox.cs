using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoSizeTextbox : MonoBehaviour
{
    [SerializeField]
    private GameObject Content;

    [SerializeField]
    private GameObject textBox;

    public void ContentSize()
    {
        //content의 크기 변경
        Vector2 pos2 = new();
        float height = textBox.GetComponent<RectTransform>().sizeDelta.y;
        pos2.y = height;
        Content.GetComponent<RectTransform>().sizeDelta = pos2;

        //텍스트 위치 수정
        pos2 = textBox.transform.localPosition;
        pos2.y = -((height / 2) + 16);
        textBox.transform.localPosition = pos2;
    }


}
