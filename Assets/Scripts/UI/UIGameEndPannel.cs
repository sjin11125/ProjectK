using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using socket.io;
using UniRx;
using UnityEngine.SceneManagement;
using System;

public class UIGameEndPannel : MonoBehaviour
{
    public GameObject PlayerBlue;
    public GameObject PlayerRed;
    public GameObject GameEndPannel;

    public Button GoMainBtn;        //메인화면으로 가는 버튼
    public Text CountTime;
    int count = 5;

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.socket.Value.On("GameEnd", (string name) =>
         {

             Time.timeScale = 0;     //일시정지
             name = name.Replace('"', ' ').Trim();
             GameEndPannel.SetActive(true);
             if (name.Equals("Player1"))         //플레이어 블루가 이겼당
             {
                 PlayerBlue.SetActive(true);

             }
             else                //플레이어 레드가 이겼당
             {
                 PlayerRed.SetActive(true);
             }
       

             GoMainBtn.onClick.AddListener(()=> {

                 NetworkManager.Instance.LeaveRoom();
                 Time.timeScale = 1;     //일시정지 끔
                 SceneManager.LoadScene("Lobby");
             });
             /* .Subscribe(_ =>
              {
                  /* Time.timeScale = 1;     //일시정지 끔
                   SceneManager.LoadScene("Lobby");

                  CountTime.text = count.ToString();

              }).AddTo(this);
          });*/

             /*GoMainBtn.OnClickAsObservable().Subscribe(_ => {


             });*/
         });
    }

}
