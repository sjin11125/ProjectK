using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_Control : MonoBehaviour {
    public GameObject Bossmonster;
    public static bool mission1 = false;
    public static bool m1_1_clear = false;
    public static bool m1_2_clear = false;
    public static bool m1_3_clear = false;
    public static bool mission2 = false;
    public static bool mission3 = false;
    // Use this for initialization
    void Start () {
		
	} 
	
	// Update is called once per frame
	void Update () {
        if (Monster_Control.monster_kill >= 20 && BossMonster_Control.boss_death == false)
        {
            m1_1_clear = true;
            Bossmonster.SetActive(true);
        }
        if (Monster_Control.monster_kill >= 20 &&BossMonster_Control.boss_death==true)
        {
            m1_2_clear = true;
        }
        if (m1_1_clear == true && m1_2_clear == true && m1_3_clear == true)
        {
            mission1 = true;
        }
        
        //mission2는 Treasure 스크립트에 있음.
	}
}
