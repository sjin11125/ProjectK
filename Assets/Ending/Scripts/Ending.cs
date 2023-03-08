using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {
    public GameObject true_ending;
    public GameObject hidden_ending;
    public GameObject bad_ending;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (To_Ending.earth==true)
        {
            true_ending.SetActive(true);
        }
        else if(To_Ending.nyang==true)
        {
            hidden_ending.SetActive(true);
        }
        else if (Player_control.health<=0)
        {
            bad_ending.SetActive(true);
        }
	}


}
