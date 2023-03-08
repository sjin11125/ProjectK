using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryHeal_control : MonoBehaviour
{
    public GameObject battery_heal_text;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "kimrobot")
        {
            battery_heal_text.SetActive(true);
            StartCoroutine(Cooltime());     //5초후 배터리 증가하는 코루틴 실행
            
        }
    }

    void OnTriggerExit(Collider other)

    {
        if (other.tag=="kimrobot")
        {
            battery_heal_text.SetActive(false);
        }
    }
    IEnumerator Cooltime()
    {
        yield return new WaitForSeconds(5f);        //5초 기다림
        Player_control.health = 3;         //김로봇의 배터리를 3으로 회복시킴
    }
}
