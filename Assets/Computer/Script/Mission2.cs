using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission2 : MonoBehaviour {

    public GameObject g;        //미션 내용
    public static GameObject rejection;        // Mission1을 클리어 하지않고 Mission2를 눌렀을 경우 나오는 경고문
    public GameObject rejection_text;

    public GameObject mission3;

    public GameObject go_to_earth;

    public Text t;     //버튼의 텍스트

   // bool on;            // 미션 내용이 보여지고 있는지

  

	// Use this for initialization
	void Start () {
        g.SetActive(false);
        
        rejection = rejection_text;
        

       // Mission_Control.m1_3_clear = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Mission_Control.mission3 == true)
        {
            mission3.SetActive(true);
        }
    }
    public void Missiong2()
    {
        if (Mission_Control.mission1 == false && Mission_Control.mission2 == false 
            && Mission.on == false && Mission_Control.m1_1_clear == true 
            && Mission_Control.m1_2_clear == true) 
        {
            Mission_Control.m1_3_clear = true;
            g.SetActive(true);
            Mission.on = true;
            rejection.SetActive(false);
            t.GetComponent<Text>().text = "끄기";
        }
        else if (Mission_Control.mission1 == true && Mission_Control.mission2 == false
            && Mission.on == true && Mission_Control.m1_1_clear == true)//mission1을 클리어하고 미션내용을 보고있는지
        {
            g.SetActive(false);
            Mission.on = false;
            t.GetComponent<Text>().text = "mission  2";
        }
        else if (Mission_Control.mission1 == true && Mission_Control.mission2 == false
        && Mission.on == false && Mission_Control.m1_1_clear == true)//mission1을 클리어하고 미션내용을 보고있는지
        {
            g.SetActive(true);
            Mission.on = true;
            t.GetComponent<Text>().text = "끄기";
        }




        if (Mission_Control.mission1 == true && Mission_Control.mission2 == true && Mission.on == true)
        {
            g.SetActive(false);
            Mission.on = false;
            rejection.SetActive(false);
            go_to_earth.SetActive(false);
            t.GetComponent<Text>().text = "mission  2";
        }
        else if (Mission_Control.mission1 == true && Mission_Control.mission2 == true && Mission.on == false)
        {
          
            g.SetActive(true);
            Mission.on = true;
            rejection.SetActive(false);
            go_to_earth.SetActive(true);
            t.GetComponent<Text>().text = "끄기";
        }




        else if (Mission_Control.mission1 == false && Mission_Control.mission2 == false && Mission.on == false && Mission_Control.m1_1_clear == false)      //미션1을 클리어하지 않고 미션2를 볼 경우 권한허용이 없다는 메시지 출력
        {
            rejection.SetActive(true);
            Mission.on = true;
            t.GetComponent<Text>().text = "끄기";
        }

        else if (Mission_Control.mission1 == false && Mission_Control.mission2 == false && Mission.on == true && Mission_Control.m1_1_clear == false)
        {
            Mission.on = false;
            rejection.SetActive(false);
            t.GetComponent<Text>().text = "mission  2";
        }

      


    }
}
