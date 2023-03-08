using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_true : MonoBehaviour {
    public GameObject treasure_check;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "kimrobot")
        {
            YesButtn.treasure = true;
            treasure_check.SetActive(true);

        }
    }
}
