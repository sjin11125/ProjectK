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

    public ReactiveProperty<bool> IsOtherCharacterMove;     //�ٸ� ĳ���Ͱ� ��������?!!?!!?!?!?!?!?!?
    public ReactiveProperty<MovePosDir> OtherCharacterMove; //�ٸ� ĳ���Ͱ� ������ ��ġ

    public ReactiveProperty<int> RandomSeed;

    public PlayerName player= PlayerName.None;

    public ReactiveProperty<Func> Funcs;
    
    void Start()
    {
      socket.Value = Socket.Connect("http://localhost:4444");

        socket.Value.On(SystemEvents.connect, () =>{
            Debug.Log("���� ����");
        });

        socket.Value.On("CreateRoom", (string Id) => {
            Debug.Log("�� id: " + Id);
            player = PlayerName.Player1;        //���� ���� ���� �÷��̾ Player1���� ����
            roomId.Value = Id;      //�� Id ����

            SceneManager.LoadScene("Room");         //�� �� �ε�
        });
        
        socket.Value.On("GameStart", (string seed) => {
            Debug.Log(" ���� ��ŸƮ");

            if (player == PlayerName.None)
             player = PlayerName.Player2;

            RandomSeed.Value =int.Parse(seed);
        

            SceneManager.LoadScene("Multi");
        });

        socket.Value.On("EnterRoom", (string enter) => {
            

            if (player == PlayerName.None)
             player = PlayerName.Player2;   //�ڽ��� Player2�� ����
            SceneManager.LoadScene("Room"); //���̵�


        });


        socket.Value.On("MoveOtherPlayer", (string pos) => {

            IsOtherCharacterMove.Value = true;
            MovePosDir movePosDir = JsonUtility.FromJson<MovePosDir>(pos);
            if (movePosDir.PlayerName!= player.ToString())      //�����̴� ĳ���Ͱ� �� ĳ���Ͱ� �ƴ϶��
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
        string MoveToJson = JsonUtility.ToJson(move);       //�÷��̾� �̵� ���� Json ��ȯ
        //Debug.Log(MoveToJson);
        socket.Value.EmitJson("MovePlayer", MoveToJson);            //�̵� ���� ������ ����
       // "{ \"my\": \"data\" }"
    }

    public void GetItem(int index)
    {
        socket.Value.Emit("GetItem", index.ToString());
    }

    public void Attack(int damage)
    {
        AttackInfo attack;
        attack.PlayerName = player.ToString();      //������ ĳ����
        attack.Damage = damage.ToString();  //������

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
