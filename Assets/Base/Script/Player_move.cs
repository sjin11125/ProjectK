using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    Rigidbody r;
    private Animator anim;
    private CharacterController controller;
    Transform t;

    public float speed = 10.0f;

    public Camera main;
    

    float rotSpeed = 20.0f;

    float xmax = 30;
    float xmin = -30;
    //float xmax = 20;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        r = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
        t = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("AnimationPar", 0);
        if (Input.GetKey("w"))
        {
            anim.SetInteger("AnimationPar", 1);
            r.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed), Space.Self);
        }
        if (Input.GetKey("s"))
        {
            anim.SetInteger("AnimationPar", 1);
            r.transform.Translate(new Vector3(0, 0, -Time.deltaTime * speed), Space.Self);
        }
        if (Input.GetKey("d"))
        {
            anim.SetInteger("AnimationPar", 1);
            r.transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0), Space.Self);
        }
        if (Input.GetKey("a"))
        {
            anim.SetInteger("AnimationPar", 1);
            r.transform.Translate(new Vector3(-Time.deltaTime * speed, 0, 0), Space.Self);
        }
       
     

        Rotctrl();
    }
    void Rotctrl()
    {
        Vector3 rot = transform.rotation.eulerAngles;   // 현재 오브젝트의 각도를 Vector3로 반환

        rot.y += Input.GetAxis("Mouse X") * rotSpeed; //마우스의 X위치 * 회전스피드
        rot.x += Input.GetAxis("Mouse Y") *-5;   //마우스의 Y위치 * 회전스피드
        
       // rot.x = Mathf.Clamp(rot.x,0,30);
        
       /* if (rot.x >= -15 && rot.x <= 20)
        {
            // rot.x = -15;
          //  rot.y += Input.GetAxis("Mouse X") * rotSpeed; //마우스의 X위치 * 회전스피드
            rot.x -= Input.GetAxis("Mouse Y") * 5;   //마우스의 Y위치 * 회전스피드
        }*/
      
        Quaternion q = Quaternion.Euler(rot.x, rot.y,0);   //Quaternion으로 변환
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);   //자연스럽게 회전
    }
   
      


}
