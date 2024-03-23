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
        //content�� ũ�� ����
        Vector2 pos2 = new();
        float height = textBox.GetComponent<RectTransform>().sizeDelta.y;
        pos2.y = height;
        Content.GetComponent<RectTransform>().sizeDelta = pos2;

        //�ؽ�Ʈ ��ġ ����
        pos2 = textBox.transform.localPosition;
        pos2.y = -((height / 2) + 16);
        textBox.transform.localPosition = pos2;
    }


}
