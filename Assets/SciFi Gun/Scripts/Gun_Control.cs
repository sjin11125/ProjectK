using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Control : MonoBehaviour {
    public GameObject bullet;
    
    public Transform bulpos;
    public static bool gun = false;
	// Use this for initialization
	void Start () {
        bullet.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0)&&gun==false)
        {
            bullet.SetActive(true);
            Instantiate(bullet,bulpos.transform.position,bulpos.transform.rotation);

            
        }
    }
}
