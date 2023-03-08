using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour {
    public GameObject mon_prefab;
    float randomX;
    float randomZ;
    // Use this for initialization
    void Start () {
        
            InvokeRepeating("Create", 3, 6); //2초 후 부터, Create 함수를 4초마다 반복해서 실행 시킴.
        
      
	}
	
	// Update is called once per frame
	void Update () {
         
        randomX = Random.Range(-130f, -8f);//x축:-130 ~ -18 사이의 랜덤 값을 대입
        randomZ = Random.Range(-251f, -171f);//z축:-251 ~ -171 사이의 랜덤 값을 대입
        // StartCoroutine(Create_Monster());
    }
    void Create()
    {
        Instantiate(mon_prefab, new Vector3(randomX, 69f, randomZ), Quaternion.identity);
    }

}
