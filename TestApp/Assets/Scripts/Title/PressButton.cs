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
    private bool isPressed = false;     //누름 확인

    [SerializeField]
    private Slider slider;
    private float sliderValue = 0f;

    DBManager dBManager;


    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        pressStartTime = Time.time;
    }

    //지정 구역 외 버튼 손 뗌
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
            // 모바일 터치 입력 및 에디터에서의 마우스 입력 감지
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) || Input.GetMouseButton(0))
            {
                if (isPressed)
                {
                    sliderValue += Time.deltaTime;
                    slider.value = sliderValue / holdDuration;
                }
                // 버튼이 눌린 상태에서 일정 시간이 지나면 꾹 누르는 동작을 처리
                if (isPressed && Time.time - pressStartTime >= holdDuration)
                {
                    Debug.Log("버튼을 꾹 눌렀습니다.");
                    // 꾹 누르기에 대한 추가적인 동작을 여기에 추가하세요.
                    dBManager.IsClick = true;

                }
            }
        }
    }
}
