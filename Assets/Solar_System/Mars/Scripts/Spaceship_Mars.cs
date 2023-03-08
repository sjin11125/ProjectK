using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Mars : MonoBehaviour {
    public GameObject pannel;
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
            Time.timeScale = 0;
            pannel.SetActive(true);

        }

    }
 
}
