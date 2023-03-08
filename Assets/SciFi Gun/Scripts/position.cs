using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class position : MonoBehaviour {
    public GameObject endpos;
    public Text t;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(endpos.transform);
        float distance= Vector3.Distance(endpos.transform.position, transform.position);
        
    }
}
