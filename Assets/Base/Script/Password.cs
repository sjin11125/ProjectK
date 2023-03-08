using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour {
    public InputField inputfield;
    public GameObject mission3_open;
    public GameObject hiddenbox_image;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void Mission3()
    {
        if (inputfield.text == "20unity")
        {
            Mission_Control.mission3 = true; //미션3이 열렸습니다.
            mission3_open.SetActive(true);
            hiddenbox_image.SetActive(false);
        }
    }
}
