using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "kimrobot")
        {//목성의 위성인 유로파에 열쇠 냥냥별보다 더 빨리 무기를 찾아야 지구를 지킬 수 있다. 행운을 빌지.
            Player_control.key = true;
            Destroy(this.gameObject);
        }
}
}
