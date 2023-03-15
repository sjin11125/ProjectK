using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    KPlayer Player;

    public SkillManager SkillManager;
    
    public UnityEvent LevelUp;          //������ �̺�Ʈ ����

    public Dictionary<string, SkillInfo> AllSkills = new Dictionary<string, SkillInfo>();        //��� ��� ����
    private void Start()
    {
        LevelUp.AddListener(SkillLevelUp);
    }

    public void SkillLevelUp()
    {
        SkillManager.gameObject.SetActive(true);            //��ų ������ �˾� Ȱ��ȭ

    }
}
