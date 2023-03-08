using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mission_Notice : MonoBehaviour {
    public Text notice;
    
    string m1_1;
    string m1_2;
    string m1_3;
    string m2_1;
    string m2_2;
    // Use this for initialization
    void Start () {
      //  m1_1 = "몬스터를 처치하세요!\n"+Monster_Control.monster_kill.ToString()+"/20";
      //  m1_2 = "보스몬스터를 처치하세요!";
        //m1_3 = "우주 탐사선을 타고 기지로 돌아가\n미션을 확인하세요!";
	}
	
	// Update is called once per frame
	void Update ()
    {
        m1_1 = "화성에서 몬스터를 처치하세요!\n" + Monster_Control.monster_kill.ToString() + "/20";
        m1_2 = "보스몬스터를 처치하세요!";
        m1_3 = "열쇠를 가지고 기지로 돌아가\n미션을 확인하세요!";

        m2_1 = "유로파로 가서 아이템을 찾으세요!";
        m2_2 = "찾은 아이템을 들고 기지로 돌아가\n미션을 확인하세요!";
        if (Mission_Control.mission1==false && Mission_Control.m1_1_clear ==false)
        {
            notice.text = m1_1;
        }
        else if (Mission_Control.mission1 == false &&
            Mission_Control.m1_1_clear == true&&
            Mission_Control.m1_2_clear==false&&
            Mission_Control.m1_3_clear == false)
        {
            notice.text = m1_2;
        }
        else if (Mission_Control.mission1 == false &&
            Mission_Control.m1_1_clear == true &&
            Mission_Control.m1_2_clear == true&&
            Mission_Control.m1_3_clear == false)
        {
            notice.text = m1_3;
            //Mission_Control.mission1 = true; 
        }
        else if (Mission_Control.mission1==true && Mission_Control.mission2==false)
        {
            notice.text = m2_1;
        }
        else if (Mission_Control.mission1 == true && Mission_Control.mission2 == true)
        {
            notice.text = m2_2;
        }
	}
}
