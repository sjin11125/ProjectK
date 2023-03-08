using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Animation : MonoBehaviour {
    private Animator anim;
    bool space = false;
    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && space == false) 
        {
            anim.SetBool("space",true);
            space = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && space == true)
        {
            anim.SetBool("space", false);
            space = false;
        }
    }
}
