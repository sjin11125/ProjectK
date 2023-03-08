using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButton : MonoBehaviour {

    public GameObject panel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void No()
    {
        Time.timeScale = 1;     //일시정지 중지
        panel.SetActive(false);
    }
}
