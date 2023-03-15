using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    KPlayer Player;

    public SkillManager SkillManager;
    
    public UnityEvent LevelUp;          //레벨업 이벤트 변수

    private void Start()
    {
    }

    public void SkillLevelUp()
    {
        SkillManager.gameObject.SetActive(true);            //스킬 레벨업 팝업 활성화

    }
}
