using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatPrefabScript : MonoBehaviour
{
    public Text PlayerName;
    public Text Message;

    public void SettingChat(string name,string message)
    {

        PlayerName.text = name;
        PlayerName.text = message;
    }

}
