using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado_Attack : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Death());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="kimrobot")
        {
            Player_control.health -= 1;
        }
    }
    IEnumerator Death()
    {
        yield  return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
