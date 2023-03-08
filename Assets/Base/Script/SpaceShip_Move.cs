using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip_Move : MonoBehaviour {
    Rigidbody r;
    public int speed = 5;      //속도
    float time = 5;
    int ttime;
    public Text time_t;
    bool booster = true;        //부스터 사용가능여부

    public Camera main;
    float rotSpeed = 12.0f;

    // Use this for initialization
    void Start () {
        r = GetComponent<Rigidbody>();
        time = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ttime = (int)time;
        time_t.text = ttime.ToString();
            r.transform.Translate(new Vector3(0, 0, -Time.deltaTime * speed) /*Space.Self*/);

        if (Input.GetKeyDown(KeyCode.Space) && booster == true )  //부스터
        {
            
           // speed *= 5;
           // booster = false;
            
             StartCoroutine(Cooltime());
            
        }
        Rotctrl();      //마우스가 움직이는 방향을 향해 카메라 회전하는 함수를 호출
    }
    IEnumerator Cooltime()
    {
        if(time>=0)
        {
            Debug.Log("booster 시작");
            speed *= 5;
            booster = false;
        }
        while(time>1)
        {
           time -= Time.deltaTime;
            
            yield return new WaitForFixedUpdate();
        }
        // yield return new WaitForSeconds(5);     //5초후 부스터 중지
        //이번 미션은 화성에 가서 몬스터를 처치하는 것이다. 그리고 몬스터들을 다 헤치우고 나면 아이템이 떨어질 것이다. 그 아이템을 획득하는게 이번 미션이다. 잘 부탁하네.
        //와 보스 몬스터를 처치하여 아이템을 획득하라.
        Debug.Log("booster 끝");
        speed /= 5;
        booster = true;
        time = 5;
        
    }
    void Rotctrl()
    {
        Vector3 rot = transform.rotation.eulerAngles;   // 현재 오브젝트의 각도를 Vector3로 반환

        rot.y += Input.GetAxis("Mouse X") * rotSpeed; //마우스의 X위치 * 회전스피드
        rot.x+= Input.GetAxis("Mouse Y") * 5;   //마우스의 Y위치 * 회전스피드
        Quaternion q = Quaternion.Euler(rot);   //Quaternion으로 변환
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);   //자연스럽게 회전
    }
}
