using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Attack : MonoBehaviour {
    GameObject monster;
    Rigidbody r;
	// Use this for initialization
	void Start () {
        monster = GameObject.Find("StoneMonster");
        r = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(monster.transform.position, transform.position);
        if (distance>=10f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            r.transform.Translate(new Vector3(Time.deltaTime * 2, 0, 0), Space.Self);
        }
	}
}
