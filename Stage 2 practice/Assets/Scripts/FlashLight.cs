using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashLight : MonoBehaviour
{
    public Light light; 
    public TMP_Text BatteryTimetext; 
    public TMP_Text batteriesText;

    public float batteryTime = 100;
    public float batteries = 0;
    public AudioSource flashOn;
    public AudioSource flashOff;

    private bool on;
    private bool off;

    void Start() // 초기화
    {
        BatteryTimetext.text = "손전등 배터리 : " + batteryTime + "%"; // 배터리 시간 문자는 "손전등 배터리 : " + 배터리 시간은 + "%"  
        light = GetComponent<Light>(); // light 함수에 컴포넌트 Light를 넣는다.

        off = true; // 손전등이 꺼져있는 상태가 true
        light.enabled = false; // light 컴포넌트를 끔.
    }

    void Update()
    {
        BatteryTimetext.text = "손전등 배터리 : " + batteryTime.ToString("0") + "%";
        batteriesText.text = "배터리 수 : " + batteries.ToString();

        if(Input.GetKeyDown(KeyCode.F) && off) // F키를 누르고 손전등이 꺼져있는 상태라면
        {
            flashOn.Play(); // flashon이라는 클립 재생하고
            light.enabled = true; // light 컴포넌트를 킴
            on = true; // 손전등 켜진 상태는 true로 변경 
            off = false; // 손전등 꺼진 상태는 false로 변경
        }

        else if (Input.GetKeyDown(KeyCode.F) && on) // F키를 누르고 손전등이 켜져있는 상태라면
        {
            flashOff.Play(); // flashoff이라는 클립 재생하고
            light.enabled = false; // light 컴포넌트를 끔
            on = false; // 손전등 켜진 상태는 false로 변경
            off = true; // 손전등 꺼진 상태는 true로 변경
        }

        if(on)
        {
            batteryTime -= 1 * Time.deltaTime; // 만약 손전등이 켜져있는 상태라면
                                                // 배터리 사용 시간을 매 프레임마다 1씩 감소한다.
        }
        
        if(batteryTime <= 0) // 배터리 시간이 0보다 작거나 같다면   
        { 
            light.enabled = false; // light 컴포넌트를 끔
            on = false; // 손전등 켜진 상태는 false로 변경
            off = true; // 손전등 꺼진 상태는 true로 변경
            batteryTime = 0; // 배터리 타임이 음수가 되는 것을 막기 위한 초기화
        }

        if(batteryTime >= 100) // 배터리 시간이 100보다 크거나 같다면
        {
            batteryTime = 100; // 배터리 시간이 100 이상을 넘어갈 수 없게 지정한다.
        }

        if(Input.GetKeyDown(KeyCode.R) && batteries >= 1) // R키를 누르고 손전등의 배터리가 1보다 크거나 같다면
        {
            batteries -= 1;  // 획득한 배터리를 1씩 감소시킨다.
            batteryTime += 50; // 배터리 사용시간이 50 프로 늘어난다.
        }

        if(Input.GetKeyDown(KeyCode.R) && batteries == 0) // R키를 누르고 배터리 수가 0이라면
        {
            return; // 배터리를 충전할 수 없음.
        }

        if(batteries <= 0) // 배터리 수가 0보다 작거나 같다면
        {
            batteries = 0; // 배터리 수를 0으로 초기화 
        }


    }
}