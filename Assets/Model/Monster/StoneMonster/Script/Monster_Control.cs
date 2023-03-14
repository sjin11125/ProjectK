using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Control : MonoBehaviour {
    public static int monster_kill = 0; //몬스터 처치 횟수
    public static int monster = 0;  //현재 몬스터 수
    public static bool death=false;
    float health = 100;     //체력
    Animator anim;
    GameObject g;
    public Text t;


    void Start () {
        death = false;
        anim =transform.parent.parent.GetComponent<Animator>();
        g = GameObject.Find("StoneMonster");
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            
            anim.SetBool("death", true);

        }
    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet" && health > 0)
        {
            health -= 10;
            Destroy(other);
        }
        else if (other.tag == "bullet" && health==0)
        {
            // monster_kill += 1;
            health = 0;
            Destroy(other);
           
        }
    

    }
  
}
