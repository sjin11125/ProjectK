using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillManager : MonoBehaviour
{
    [SerializeField]
    List<SkillInfoUI> ChoiceSkills = new List<SkillInfoUI>();

    public Dictionary<string, SkillInfo> AllSkills = new Dictionary<string, SkillInfo>();        //��� ��� ����

    public KPlayer Player;
    // Start is called before the first frame update
    private void Start()
    {
        TextAsset csvData = Resources.Load<TextAsset>("SkillList");      //��ų ���� ���� ���� �Ľ�

        string[] data = csvData.text.Split(new char[] { '\n' });    //���� �������� �ɰ�
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] == "")
                break;
            string[] skill = data[i].Split(',');            //�޸� �������� �ɰ�
       
            int[] speed = Array.ConvertAll((skill[2].Split('.')), int.Parse);
            int[] damage= Array.ConvertAll((skill[3].Split('.')), int.Parse);
            int[] radius= Array.ConvertAll((skill[4].Split('.')), int.Parse);
            int[] cooltime= Array.ConvertAll((skill[5].Split('.')), int.Parse);
            int[] count= Array.ConvertAll((skill[6].Split('.')), int.Parse);


            SkillInfo skillInfo = new SkillInfo(skill[0], skill[1], speed,damage,radius,cooltime,count);
            AllSkills.Add(skill[7], skillInfo);         //��� ��� ��ųʸ��� �߰�
        }
        SkillLevelUp();

    }

    public void SkillLevelUp()
    {

        for (int i = 0; i < 3; i++)
        {
            string randNum;
            //��ų ���� ��
            do
            {
                int randSkill = Enum.GetNames(typeof(Skill)).Length;
                randNum = ((Skill)UnityEngine.Random.Range(0, randSkill)).ToString();

            } while (ChoiceSkills.Any(x => x.skillInfo.Name == AllSkills[randNum].Name));       //�ߺ� �ȵǰ�

            ChoiceSkills[i].skillInfo = AllSkills[randNum];

            //��ų ���� �ֱ�
            ChoiceSkills[i].skillNameText.text = AllSkills[randNum].Name;
            ChoiceSkills[i].skillInfoText.text = AllSkills[randNum].Info;

        }
    }
}
