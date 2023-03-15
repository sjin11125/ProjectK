using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField]
    List<SkillInfoButton> ChoiceSkills = new List<SkillInfoButton>();

    public KPlayer Player;
    // Start is called before the first frame update
    private void OnEnable()
    {
        for (int i = 0; i < 3; i++)
        {
            //스킬 랜덤 고름
            int randSkill = Enum.GetNames(typeof(Skill)).Length;
            ChoiceSkills[i].skillInfo = GameManager.Instance.AllSkills[((Skill)UnityEngine.Random.Range(0, randSkill)).ToString()];
        }
    }
}
