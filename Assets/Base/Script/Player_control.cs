using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_control : MonoBehaviour {

    public static int health = 3;
    public static bool key = false;     //열쇠를 가지고 있는지
    public Text p;
    public GameObject key_notice;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health<=0)
        {
            SceneManager.LoadScene("ending");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "monster")
        {
            health -= 1;
        }
        if (other.tag=="key")
        {
            key_notice.SetActive(true);
        }
    }
}
