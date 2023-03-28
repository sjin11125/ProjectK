using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;
using UniRx;
public class LobbyScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Button CreateRoomBtn;
    public Text RoomIdText;
    public Button EnterRoomBtn;
    public Button SingleBtn;
    public InputField RoomIdInput;

    void Start()
    {
        //����� ��ư ����
        CreateRoomBtn.OnClickAsObservable().Subscribe(_=> {

            NetworkManager.Instance.CreateRoom();


        });

        //����� ��ư ����
        EnterRoomBtn.OnClickAsObservable().Subscribe(_=> {

            NetworkManager.Instance.roomId.Value = RoomIdInput.text;
            NetworkManager.Instance.EnterRoom(RoomIdInput.text);

        });


    }

}
