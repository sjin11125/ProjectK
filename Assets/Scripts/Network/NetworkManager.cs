using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;
using UniRx;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class NetworkManager : Singleton<NetworkManager>
{
    public ReactiveProperty<Socket> socket;
    public ReactiveProperty<string> roomId;

    public ReactiveProperty<bool> IsOtherCharacterMove;     //다른 캐릭터가 움직였니?!!?!!?!?!?!?!?!?
    public ReactiveProperty<MovePosDir> OtherCharacterMove; //다른 캐릭터가 움직인 위치

    public ReactiveProperty<int> RandomSeed;

    public PlayerName player= PlayerName.None;

    public ReactiveProperty<Func> Funcs;
    
    void Start()
    {
      socket.Value = Socket.Connect("http://localhost:4444");

        socket.Value.On(SystemEvents.connect, () =>{
            Debug.Log("연결 성공");
        });

        socket.Value.On("CreateRoom", (string Id) => {
            Debug.Log("룸 id: " + Id);
            player = PlayerName.Player1;        //제일 먼저 들어온 플레이어를 Player1으로 설정
            roomId.Value = Id;      //룸 Id 설정

            SceneManager.LoadScene("Room");         //룸 씬 로드
        });
        
        socket.Value.On("GameStart", (string seed) => {
            Debug.Log(" 게임 스타트");

            if (player == PlayerName.None)
             player = PlayerName.Player2;

            RandomSeed.Value =int.Parse(seed);
        

            SceneManager.LoadScene("Multi");
        });

        socket.Value.On("EnterRoom", (string enter) => {
            

            if (player == PlayerName.None)
             player = PlayerName.Player2;   //자신을 Player2로 설정
            SceneManager.LoadScene("Room"); //씬이동


        });


        socket.Value.On("MoveOtherPlayer", (string pos) => {

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
        socket.Value.Emit("CreateRoom");
        SceneManager.LoadScene("Room");
    }

    public void EnterRoom(string id)
    {
        socket.Value.Emit("EnterRoom",id);
 
    }
    public void MovePlayer(Vector3 dir,Vector3 pos)
    {
        MovePosDir move;
        move.RoomId = roomId.Value;
        move.PlayerName = player.ToString();
        move.Dir = dir;
        move.Pos = pos;
        string MoveToJson = JsonUtility.ToJson(move);       //플레이어 이동 정보 Json 변환
        //Debug.Log(MoveToJson);
        socket.Value.EmitJson("MovePlayer", MoveToJson);            //이동 정보 서버에 전송
       // "{ \"my\": \"data\" }"
    }

    public void GetItem(int index)
    {
        socket.Value.Emit("GetItem", index.ToString());
    }

    public void Attack(int damage)
    {
        AttackInfo attack;
        attack.PlayerName = player.ToString();      //공격한 캐릭터
        attack.Damage = damage.ToString();  //데미지

        string AttackToJson = JsonUtility.ToJson(attack);
        socket.Value.EmitJson("Attack", AttackToJson);
    }
    public void SkillUpdate(string skillName, string level)
    {
        SkillInfos skillInfo;
        skillInfo.SkillName = skillName;
        skillInfo.level = level;

        string SkillToJson = JsonUtility.ToJson(skillInfo);
        socket.Value.EmitJson("SkillUpdate", SkillToJson);
    }

    public void SendMessage(string name, string message)
    {
        ChatInfo chatInfo;
        chatInfo.PlayerName = name;
        chatInfo.Message = message;

        string MessageToJson = JsonUtility.ToJson(chatInfo);
        socket.Value.EmitJson("SendMessage", MessageToJson);
    }

    public void Ready()
    {
        socket.Value.Emit("Ready");
    }
    public void GameStart()
    {
        socket.Value.Emit("GameStart");
    }

    public void GameEnd(string name)
    {
        socket.Value.Emit("GameEnd", name);

    }
}
