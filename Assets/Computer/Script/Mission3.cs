using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission3 : MonoBehaviour {
 

    public Text t;     //버튼의 텍스트

    public GameObject g;        //미션 내용

    public GameObject nyang;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Missiong3()
    {
        if (Mission_Control.mission2 == false&&Mission.on == false)
        {
            g.SetActive(true);
            Mission.on = true;
            t.GetComponent<Text>().text = "끄기";
            
        }
        else if (Mission_Control.mission2 == false&&Mission.on==true)
        {
            g.SetActive(false);
            Mission.on = false;
            t.GetComponent<Text>().text = "mission  3";
        }

        if (Mission_Control.mission2==true&& Mission.on == false)
        {
            nyang.SetActive(true);
            g.SetActive(true);
            Mission.on = true;
            t.GetComponent<Text>().text = "끄기";
        }
        else if (Mission_Control.mission2 == true && Mission.on == true)
        {
            nyang.SetActive(false);
            g.SetActive(false);
            Mission.on = false;
            t.GetComponent<Text>().text = "mission  3";
        }
    }
}
