using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShip_board : MonoBehaviour {

    public GameObject Kimrobot;     //김로봇 오브젝트

    public GameObject spaceship_camera;     //우주선의 카메라

    bool put_in = false;         //비행기에 탑승했는가?

    public GameObject F;              // 탑승키(F)를 알려주는 텍스트
    public GameObject D;               // 하차키(D)를 알려주는 텍스트

    Rigidbody r;

    void Start () {
        F.SetActive(false);
        r = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D) && put_in == true)
        {
            put_in = false;         // 탑승여부를 false로 바꿈
            Kimrobot.SetActive(true);       //김로봇을 보이게 함
            spaceship_camera.SetActive(false);  //우주선에 초점이 맞춰진 카메라를 끔.
            D.SetActive(false);
        }

        if (Input.GetKey(KeyCode.W) && put_in==true)
        {
             r.transform.Translate(new Vector3(0, 0, -Time.deltaTime * 10), Space.Self);
           // anim.SetBool("W",true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "kimrobot")
        {
            F.SetActive(true);          // 김로봇과 우주선이 충돌할 때 탑승방법을 알려줌.
            D.SetActive(false);
            if (Input.GetKey(KeyCode.F) && put_in == false)     //김로봇과 우주선이 충돌한 채로 F키를 누르면 탑승
            {
                spaceship_camera.SetActive(true);
                Kimrobot.SetActive(false);
                put_in = true;
                F.SetActive(false);
                D.SetActive(true);

            }
            
            
        }
       
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "kimrobot")
        {
            F.SetActive(false);
           // D.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="earth")
        {
            SceneManager.LoadScene("sspace");
        }
    }
}
