using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoGenerator2 : MonoBehaviour {
    bool ok=false;
    public GameObject tornado;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(Warning());
        }
        Instantiate(tornado);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Warning()
    {
        this.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);
    }
}
