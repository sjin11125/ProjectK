using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using socket.io;
using UnityEngine.SceneManagement;
public class RoomScene : MonoBehaviour
{
    // Start is called before the first frame update

    public Button ReadyBtn;
    public Button StartBtn;
    public Image Player2Img;

    public GameObject ChatConent;
    public InputField ChatMessage;
    public Button ChatSendBtn;
    public GameObject ChatPrefab;

    public Text RoomIdText;

    bool isReady;
    void Start()
    {
        RoomIdText.text = NetworkManager.Instance.roomId.Value;
        if (NetworkManager.Instance.player==PlayerName.Player2)
        {
            Player2Img.gameObject.SetActive(true);
        }

        NetworkManager.Instance.socket.Value.On("RecieveMessage",(string message)=> {

            ChatInfo chatInfo = JsonUtility.FromJson<ChatInfo>(message);

            GameObject ChatObj = Instantiate(ChatPrefab, ChatConent.transform) as GameObject;

            ChatPrefabScript chat = ChatObj.GetComponent<ChatPrefabScript>();
            chat.SettingChat(chatInfo.PlayerName, chatInfo.Message);

        });

        NetworkManager.Instance.socket.Value.On("EnterRoom", (string id)=> {
            Player2Img.gameObject.SetActive(true);

        });

        NetworkManager.Instance.socket.Value.On("Ready", (string id)=> {

            isReady = true;
            ReadyBtn.enabled = false;
        });
        ChatSendBtn.OnClickAsObservable().Subscribe(_ => {           //채팅 Send 눌럿을때


            NetworkManager.Instance.SendMessage(NetworkManager.Instance.player.ToString(), ChatMessage.text);

        });
        ReadyBtn.OnClickAsObservable().Subscribe(_=> {

            if (NetworkManager.Instance.player== PlayerName.Player2)
            {
                NetworkManager.Instance.Ready();
                ReadyBtn.enabled = false;
            }
        });
        StartBtn.OnClickAsObservable().Subscribe(_=> {

            if (NetworkManager.Instance.player == PlayerName.Player1
                &&isReady)
            {
               // SceneManager.LoadScene("Multi");
                NetworkManager.Instance.GameStart();
            }
        });

    }

}
