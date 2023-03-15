using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    Idle,
    Move,
    Attack,
    Skill

}

public enum Skill
{
    Basic,      //기본 공격
    Top,        //팽이
    Shield,         //방어막
    Bomb,     //폭탄
    Thunder,        //번개 발사기
}

