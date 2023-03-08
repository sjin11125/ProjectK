using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_false : MonoBehaviour {
    public GameObject treasure_check;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="kimrobot")
        {
            YesButtn.treasure = false;
            treasure_check.SetActive(true);

        }
    }
}
