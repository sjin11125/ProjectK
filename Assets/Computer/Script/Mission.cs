using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour {
    
    

   // public static bool mission1 = false;        //Mission1을 클리어 했는가
    public static bool on;            // 미션 내용이 보여지고 있는지

    public GameObject g;        // 미션의 내용

    public Text t;

    // Use this for initialization
    void Start () {

        //trans = transform.GetChild(1);//t.GetChild(1);
        // trans.gameObject.SetActive(false);
        g.SetActive(false);
         on = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Missiong()
    {
         if ((Mission_Control.mission1 == false && on == false)|| (Mission_Control.mission1 == true && on == false))  //mission1을 클리어하지 않음.
         {
             //trans.gameObject.SetActive(true);
             g.SetActive(true);
             on = true;
            Mission2.rejection.SetActive(false);        //경고문 삭제
            t.GetComponent<Text>().text = "끄기";
        }
         else if ((Mission_Control.mission1 == false && on == true)|| (Mission_Control.mission1 == true && on == true))
         {
             //trans.gameObject.SetActive(false);
             g.SetActive(false);
             on = false;
            t.GetComponent<Text>().text = "mission  1";
        }
        //g.SetActive(true);

    }
}
