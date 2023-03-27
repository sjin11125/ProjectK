using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


[Serializable]
public class SkillInfo
{
    public string Name;
    public string Info;
    public int[] Speed ;
    public int[] Damage;
    public float[] Radius;
    public int[] CoolTime;
    public int[] Count ;      //����

    public string EngName;

    public SkillInfo(string name, string info, int[] speed, int[] damage,  float[] radius, int[] coolTime, int[] count,string engName)
    {
        Name = name;
        Info = info;
        Speed = speed;
        Damage = damage;
        Radius = radius;
        CoolTime = coolTime;
       Count = count;
        EngName = engName;
    }
    // public int range ;      //����

}
[Serializable]
public class SkillInfoUI
{
   public SkillInfo skillInfo;
    public Button Btn;
    public Text skillNameText;
    public Text skillInfoText;
    [SerializeField]
    public List<Image> skillLevelImage;

}
[Serializable]
public struct MovePosDir
{
    public string PlayerName;
    public string RoomId;
    public Vector3 Pos;
    public Vector3 Dir;
}
[Serializable] 
public struct AttackInfo
{
    public string PlayerName;           //�����ѻ�� �̸�
    public string Damage;           //������
}
[Serializable] 
public struct SkillInfos
{
    public string SkillName;           //��ų ����
    public string level;           //����
}
[Serializable] 
public struct ChatInfo
{
    public string PlayerName;           //�÷��̾� �̸�
    public string Message;           //����
}