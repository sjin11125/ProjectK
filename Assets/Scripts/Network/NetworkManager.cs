using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using socket.io;

public class NetworkManager : MonoBehaviour
{
    void Start()
    {
        var socket = Socket.Connect("http://localhost:8000");
      /*  socket.On(SystemEvents.connect, () =>{
            Debug.Log("연결 성공");
        });*/
    }

}
