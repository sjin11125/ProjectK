using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_controller : MonoBehaviour {
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Player_control.health==2)
        {
            b3.SetActive(false);
            b2.SetActive(true);
            b1.SetActive(true);
        }
        else if (Player_control.health == 1)
        {
            b3.SetActive(false);
            b2.SetActive(false);
            b1.SetActive(true);
        }
        else if(Player_control.health == 0|| Player_control.health < 0)
        {
            b1.SetActive(false);
            b2.SetActive(false);
            b3.SetActive(false);
        }
        if(Player_control.health == 3)
        {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
        }
	}
}
