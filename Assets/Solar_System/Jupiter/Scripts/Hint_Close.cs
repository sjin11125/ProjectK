using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_Close : MonoBehaviour {
    public GameObject hint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Close()
    {
        hint.SetActive(false);
    }
}
