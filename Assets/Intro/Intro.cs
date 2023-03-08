using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public Text t;
    int index;
    bool on;

    
    string[] text = { "서기 2290년, 인류는 우주에서 일어나는 많은 재난들을 해결하기 위해 로봇을 만들어 쏘아 올렸다.",
        "그러던 어느날, 국제항공우주국인 NASA는 지구를 멸망시키려는 냥냥별을 발견하였다.",
        "운이 좋게도 NASA는 목성의 위성인 '유로파'라는 행성에서 외계인들을 몰살시킬 수 있는 무기가 있다는 사실을 알게 되고",
        " 그 무기를 획득하기 위해 '김로봇'이라는 로봇을 만들어 우주로 쏘아 올렸다.",
    "과연 김로봇은 무기를 획득하고 지구를 지킬 수 있을까?" };
    // Use this for initialization
    void Start()
    {
        index = 0;
        on = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && on == false && index != text.Length )
        {
            on = true;
            StartCoroutine(MakeTime(index));
            ++index;
            

        }
        else if (Input.anyKeyDown &&index==text.Length && on == false)
        {
            SceneManager.LoadScene("base");
        }
    }
    IEnumerator MakeTime(int index)
    {
        
        for (int i = 0; i < text[index].Length+1; i++)
        {
            t.text = text[index].Substring(0, i);
            yield return new WaitForSeconds(0.05f);
            
        }
        on = false;

    }
}
