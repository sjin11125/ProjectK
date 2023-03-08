using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nobuttn : MonoBehaviour {
    public GameObject treasure_check;
    //public GameObject unity_notice;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click()
    {
        treasure_check.SetActive(false);
    }
   
}
