using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {
    public GameObject unity_notice;
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
            Mission_Control.mission2 = true;
            unity_notice.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
