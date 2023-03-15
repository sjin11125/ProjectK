using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillManager : MonoBehaviour
{
    [SerializeField]
    List<SkillInfoUI> ChoiceSkills = new List<SkillInfoUI>();

    public Dictionary<string, SkillInfo> AllSkills = new Dictionary<string, SkillInfo>();        //모든 기술 정보

    public KPlayer Player;
    // Start is called before the first frame update
    private void Start()
    {
        TextAsset csvData = Resources.Load<TextAsset>("SkillList");      //스킬 정보 엑셀 파일 파싱

        string[] data = csvData.text.Split(new char[] { '\n' });    //엔터 기준으로 쪼갬
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] == "")
                break;
            string[] skill = data[i].Split(',');            //콤마 기준으로 쪼갬
       
            int[] speed = Array.ConvertAll((skill[2].Split('.')), int.Parse);
            int[] damage= Array.ConvertAll((skill[3].Split('.')), int.Parse);
            int[] radius= Array.ConvertAll((skill[4].Split('.')), int.Parse);
            int[] cooltime= Array.ConvertAll((skill[5].Split('.')), int.Parse);
            int[] count= Array.ConvertAll((skill[6].Split('.')), int.Parse);


            SkillInfo skillInfo = new SkillInfo(skill[0], skill[1], speed,damage,radius,cooltime,count);
            AllSkills.Add(skill[7], skillInfo);         //모든 기술 딕셔너리에 추가
        }
        SkillLevelUp();

    }

    public void SkillLevelUp()
    {

        for (int i = 0; i < 3; i++)
        {
            string randNum;
            //스킬 랜덤 고름
            do
            {
                int randSkill = Enum.GetNames(typeof(Skill)).Length;
                randNum = ((Skill)UnityEngine.Random.Range(0, randSkill)).ToString();

            } while (ChoiceSkills.Any(x => x.skillInfo.Name == AllSkills[randNum].Name));       //중복 안되게

            ChoiceSkills[i].skillInfo = AllSkills[randNum];

            //스킬 정보 넣기
            ChoiceSkills[i].skillNameText.text = AllSkills[randNum].Name;
            ChoiceSkills[i].skillInfoText.text = AllSkills[randNum].Info;

        }
    }
}
