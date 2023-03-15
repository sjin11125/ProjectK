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
    public int[] Radius;
    public int[] CoolTime;
    public int[] Count ;      //°¹¼ö

    public string EngName;

    public SkillInfo(string name, string info, int[] speed, int[] damage,  int[] radius, int[] coolTime, int[] count,string engName)
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
    // public int range ;      //¹üÀ§

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