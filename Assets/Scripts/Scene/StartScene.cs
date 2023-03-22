using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Button StartBtn;
    void Start()
    {
        StartBtn.OnClickAsObservable().Subscribe(_ => {

            SceneManager.LoadScene("Lobby");

        });


    }
}
