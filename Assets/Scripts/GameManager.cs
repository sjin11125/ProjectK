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

    private void Start()
    {
    }

    public void SkillLevelUp()
    {
        SkillManager.gameObject.SetActive(true);            //��ų ������ �˾� Ȱ��ȭ

    }
}
