using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private float holdDuration = 1.0f;
    private float pressStartTime;
    private bool isPressed = false;     //���� Ȯ��

    [SerializeField]
    private Slider slider;
    private float sliderValue = 0f;

    DBManager dBManager;


    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        pressStartTime = Time.time;
    }

    //���� ���� �� ��ư �� ��
    public void OnPointerUp(PointerEventData eventData)
    {
        dBManager.IsClick = false;
        isPressed = false;
        slider.value = 0f;
        sliderValue = 0f;
    }

    private void Start()
    {
        dBManager = DBManager.Instance;
    }

    void Update()
    {
        if (!dBManager.IsClick)
        {
            // ����� ��ġ �Է� �� �����Ϳ����� ���콺 �Է� ����
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) || Input.GetMouseButton(0))
            {
                if (isPressed)
                {
                    sliderValue += Time.deltaTime;
                    slider.value = sliderValue / holdDuration;
                }
                // ��ư�� ���� ���¿��� ���� �ð��� ������ �� ������ ������ ó��
                if (isPressed && Time.time - pressStartTime >= holdDuration)
                {
                    Debug.Log("��ư�� �� �������ϴ�.");
                    // �� �����⿡ ���� �߰����� ������ ���⿡ �߰��ϼ���.
                    dBManager.IsClick = true;

                }
            }
        }
    }
}
