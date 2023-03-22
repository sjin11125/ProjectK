using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using UniRx;
using UnityEngine.SceneManagement;

public class NetworkManager : Singleton<NetworkManager>
{
    Socket socket;
    public ReactiveProperty<string> roomId;
    public PlayerName player;
    void Start()
    {
      socket = Socket.Connect("http://localhost:8000");

        socket.On(SystemEvents.connect, () =>{
            Debug.Log("연결 성공");
        });
        socket.On("CreateRoom", (string Id) => {
            Debug.Log("룸 id: " + Id);
            player = PlayerName.Player1;
            roomId.Value = Id;
        });
        
        socket.On("GameStart", (string id) => {
            Debug.Log(" 게임 스타트");
            player = PlayerName.Player2;
            SceneManager.LoadScene("Multi");
        });

    }

    public void CreateRoom()
    {
       // string roomId;
        socket.Emit("CreateRoom");
 
    }
    public void EnterRoom(string id)
    {
       // string roomId;
        socket.Emit("EnterRoom",id);
 
    }

}
