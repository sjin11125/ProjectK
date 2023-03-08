using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bossmonster_Health : MonoBehaviour {
    public Slider slider;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        slider.maxValue = 250;
        slider.value = BossMonster_Control.health;
        slider.minValue = 0;
	}
}
