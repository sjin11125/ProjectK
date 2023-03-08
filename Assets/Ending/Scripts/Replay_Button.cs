using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay_Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Replay()
    {
        Player_control.health = 3;
        SceneManager.LoadScene("base");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Sstart()
    {
        SceneManager.LoadScene("Intro"); //왼쪽 마우스 클릭 : 공격
    }
}
