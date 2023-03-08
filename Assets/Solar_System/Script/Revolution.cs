using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revolution : MonoBehaviour {
    public GameObject Sun;
    public float speed;
    LineRenderer lr;
    Vector3[] vec;
	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Sun.transform.position,Vector3.down,speed*Time.deltaTime); // 자전하는 함수
       // Line();
        
       
	}
   
}
