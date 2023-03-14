using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster_Attack : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = transform.parent.parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "kimrobot" && BossMonster_Control.health >= 0 && anim.GetBool("death") == false)
        {
            Player_control.health -= 1;     //플레이어의 체력을 2만큼 깎음.
        }
   
    }
}
