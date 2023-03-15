using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


[Serializable]
public class SkillInfo
{
    public string Name;
    public float Speed = 3;
    public float Damage;
    public int level;
    public int Radius = 1;
    public int coolTime = 5;
    public int count = 1;      //°¹¼ö
    public int range = 5;      //¹üÀ§
}
[Serializable]
public class SkillInfoButton
{
   public SkillInfo skillInfo;
    public Button Btn;

}