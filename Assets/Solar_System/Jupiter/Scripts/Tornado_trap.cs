using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_trap : MonoBehaviour {

    public GameObject tornado;
    GameObject player;
    float randomX;
    float randomZ;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("kimrobot");
        
       // InvokeRepeating("Create", 2, 1); //2초 후 부터, Create 함수를 3초마다 반복해서 실행 시킴.
    }

    // Update is called once per frame
    void Update()
    {
       
        randomX = Random.Range(player.transform.position.x + 10, player.transform.position.x - 10);//x축:플레이어 x좌표의 +-30 사이의 랜덤 값을 대입
        randomZ = Random.Range(player.transform.position.z + 10, player.transform.position.z - 10);//z축:플레이어 z좌표의 +-30사이의 랜덤 값을 대입
        Instantiate(tornado, new Vector3(randomX, 4f, randomZ), tornado.transform.rotation);

    }

    /*void Create()
    {
        Instantiate(tornado, new Vector3(randomX, 4f, randomZ), tornado.transform.rotation);
    }*/
}
