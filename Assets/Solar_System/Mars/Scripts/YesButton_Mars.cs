using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class YesButton_Mars : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Yes()
    {
        SceneManager.LoadScene("sspace");
     
            Time.timeScale = 1;
         
    }
}
