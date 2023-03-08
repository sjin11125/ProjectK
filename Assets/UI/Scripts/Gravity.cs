using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    void OnTriggerStay(Collider other)
    {
        // 콜라이더에 접촉하고 있는 오브젝트의 Rigidbody컴포넌트를 취득 		
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // 공이 어느 방향에 있는지를 계산		
        Vector3 direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();

       
            // 중심 지점에서 공을 멈추기 위해 속도를 감속시킨다 			
            r.velocity *= 0.5f;
            r.AddForce(direction * r.mass * 20.0f);
            //
        
    }
}
