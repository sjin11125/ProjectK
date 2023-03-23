using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using UniRx;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class NetworkManager : Singleton<NetworkManager>
{
    Socket socket;
    public ReactiveProperty<string> roomId;
    public ReactiveProperty<bool> IsOtherCharacterMove;     //다른 캐릭터가 움직였니?!!?!!?!?!?!?!?!?
    public ReactiveProperty<MovePosDir> OtherCharacterMove;     //다른 캐릭터가 움직였니?!!?!!?!?!?!?!?!?
    public PlayerName player= PlayerName.None;
    
    void Start()
    {
      socket = Socket.Connect("http://localhost:4444");

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

            if (player == PlayerName.None)
             player = PlayerName.Player2;

            roomId.Value = id;
        

            SceneManager.LoadScene("Multi");
        });
        //socket.On
        socket.On("MoveOtherPlayer", (string pos) => {
            Debug.Log(" 캐릭터 움직임");
            IsOtherCharacterMove.Value = true;
            MovePosDir movePosDir = JsonUtility.FromJson<MovePosDir>(pos);
            if (movePosDir.PlayerName!= player.ToString())      //움직이는 캐릭터가 내 캐릭터가 아니라면
            {
                OtherCharacterMove.Value = movePosDir;
            }
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
    public void MovePlayer(Vector3 dir,Vector3 pos)
    {
        MovePosDir move=new MovePosDir();
        move.RoomId = roomId.Value;
        move.PlayerName = player.ToString();
        move.Dir = dir;
        move.Pos = pos;
        string MoveToJson = JsonUtility.ToJson(move);
        //Debug.Log(MoveToJson);
        socket.EmitJson("MovePlayer", MoveToJson);
       // "{ \"my\": \"data\" }"
    }

}
