using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesButtn : MonoBehaviour {
    GameObject player;
    public static bool treasure;
    public GameObject treasure2;
    public GameObject treasure_check;
    public GameObject tornado_trap;
    public GameObject hidden_box;
    public GameObject no_key_notice;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindWithTag("kimrobot");
    }
    public void Click()
    {
        if (treasure==false && Player_control.key == true)
        {
            treasure_check.SetActive(false);
            tornado_trap.SetActive(true);
        }
        else if (treasure == true && Player_control.key == true)
        {
            treasure2.SetActive(true);          //unity 생성
            treasure_check.SetActive(false);
        }
        else if ( Player_control.key == false)
        {
            treasure_check.SetActive(false);
            no_key_notice.SetActive(true);
        }
    }

    public void Hidden_Click()
    {
        treasure_check.SetActive(false);
        hidden_box.SetActive(true);
    }
}
