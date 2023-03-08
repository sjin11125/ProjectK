
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Use : MonoBehaviour {
    public GameObject u;
    public Text t;
    // Use this for initialization
    void Start () {
        u.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Use1()
    {
        if (Mission.on==false && Mission.on == false)
        {
            u.SetActive(true);
            Mission.on = true;
            t.GetComponent<Text>().text = "끄기";
        }
        else if(Mission.on==true && Mission.on == true)
        {
            u.SetActive(false);
            Mission.on = false;
            t.GetComponent<Text>().text = "사    용    법";
        }
    }

}
